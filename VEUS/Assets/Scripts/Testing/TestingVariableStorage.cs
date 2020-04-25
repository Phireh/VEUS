﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Yarn.Unity;

namespace Yarn.Unity
{

    /// An extremely simple implementation of DialogueUnityVariableStorage,
    /// which just stores everything in a Dictionary in memory.
    public class TestingVariableStorage : VariableStorageBehaviour, IEnumerable<KeyValuePair<string, Yarn.Value>>
    {

        /// Where we actually keeping our variables
        Dictionary<string, Yarn.Value> variables = new Dictionary<string, Yarn.Value>();

        /// A default value to apply when the object wakes up, or when
        /// ResetToDefaults is called
        [System.Serializable]
        public class DefaultVariable
        {
            /// Name of the variable
            public string name;
            /// Value of the variable
            public string value;
            /// Type of the variable
            public Yarn.Value.Type type;
        }

        /// Our list of default variables, for debugging.
        public DefaultVariable[] defaultVariables;

        [Header("Optional debugging tools")]
        /// A UI.Text that can show the current list of all variables.
        /// Optional.
        public UnityEngine.UI.Text debugTextView;

        /// Reset to our default values when the game starts
        void Awake()
        {
            ResetToDefaults();
            
        }

        /// Erase all variables and reset to default values
        public override void ResetToDefaults()
        {
            Clear();

            // For each default variable that's been defined, parse the
            // string that the user typed in in Unity and store the
            // variable
            foreach (var variable in defaultVariables)
            {

                object value;

                switch (variable.type)
                {
                    case Yarn.Value.Type.Number:
                        float f = 0.0f;
                        float.TryParse(variable.value, out f);
                        value = f;
                        break;

                    case Yarn.Value.Type.String:
                        value = variable.value;
                        break;

                    case Yarn.Value.Type.Bool:
                        bool b = false;
                        bool.TryParse(variable.value, out b);
                        value = b;
                        break;

                    case Yarn.Value.Type.Variable:
                        // We don't support assigning default variables from
                        // other variables yet
                        Debug.LogErrorFormat("Can't set variable {0} to {1}: You can't " +
                            "set a default variable to be another variable, because it " +
                            "may not have been initialised yet.", variable.name, variable.value);
                        continue;

                    case Yarn.Value.Type.Null:
                        value = null;
                        break;

                    default:
                        throw new System.ArgumentOutOfRangeException();

                }

                var v = new Yarn.Value(value);

                SetValue("$" + variable.name, v);
            }
        }

        /// Set a variable's value
        public override void SetValue(string variableName, Yarn.Value value)
        {
            // Copy this value into our list
            variables[variableName] = new Yarn.Value(value);
        }

        /// Get a variable's value
        public override Yarn.Value GetValue(string variableName)
        {
            // If we don't have a variable with this name, return the null
            // value

            /* TESTING */
            switch (variableName)
            {

                case "$_random":
                float f = Random.Range(0f, 1f);
                Yarn.Value outValue = new Yarn.Value(f);
                return outValue;
    
                default:
                if (variables.ContainsKey(variableName) == false)
                   return Yarn.Value.NULL;
                return variables[variableName];
            }      
        }

        /// Erase all variables
        public override void Clear()
        {
            variables.Clear();
        }

        /// If we have a debug view, show the list of all variables in it
        void Update()
        {
            if (debugTextView != null)
            {
                var stringBuilder = new System.Text.StringBuilder();
                foreach (KeyValuePair<string, Yarn.Value> item in variables)
                {
                    string debugDescription;
                    switch (item.Value.type)
                    {
                        case Value.Type.Bool:
                            debugDescription = item.Value.AsBool.ToString();
                            break;
                        case Value.Type.Null:
                            debugDescription = "null";
                            break;
                        case Value.Type.Number:
                            debugDescription = item.Value.AsNumber.ToString();
                            break;
                        case Value.Type.String:
                            debugDescription = $@"""{item.Value.AsString}""";
                            break;
                        default:
                            debugDescription = "<unknown>";
                            break;

                    }
                    stringBuilder.AppendLine(string.Format("{0} = {1}",
                                                            item.Key,
                                                            debugDescription));
                }
                debugTextView.text = stringBuilder.ToString();
                debugTextView.SetAllDirty();
            }
        }

        public IEnumerator<KeyValuePair<string, Value>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, Value>>)variables).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, Value>>)variables).GetEnumerator();
        }
    }
}