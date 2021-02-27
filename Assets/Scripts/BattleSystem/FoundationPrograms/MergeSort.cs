using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Object = System.Object;

class MergeSort
    {
        public enum SortType{Health, Mana, Atk, Def, Eva, Speed};
   
        public static Character[] charactermergeSort(Character[] array, bool isAscending, SortType sortType)
        {
            Character[] left;
            Character[] right;
            Character[] result = new Character[array.Length];  
            //As this is a recursive algorithm, we need to have a base case to 
            //avoid an infinite recursion and therfore a stackoverflow
            if (array.Length <= 1)
                return array;              
            // The exact midpoint of our array  
            int midPoint = array.Length / 2;  
            //Will represent our 'left' array
            left = new Character[midPoint];
  
            //if array has an even number of elements, the left and right array will have the same number of 
            //elements
            if (array.Length % 2 == 0)
                right = new Character[midPoint];  
            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new Character[midPoint + 1];  
            //populate left array
            for (int i = 0; i < midPoint; i++)
                left[i] = array[i];  
            //populate right array   
            int x = 0;
            //We start our index from the midpoint, as we have already populated the left array from 0 to midpont
            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }  
            //Recursively sort the left array
            left = charactermergeSort(left, isAscending, sortType);
            //Recursively sort the right array
            right = charactermergeSort(right, isAscending, sortType);
            //Merge our two sorted arrays
            result = charactermerge(left, right, isAscending, sortType);  
            return result;
        }

        public static Character[] charactermerge(Character[] left, Character[] right, bool isAscending, SortType sortType)
        {
            int resultLength = right.Length + left.Length;
            Character[] result = new Character[resultLength];
            //
            int indexLeft = 0, indexRight = 0, indexResult = 0;  
            //while either array still has an element
            // Ascending Sort

            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)  
                {  
                    // Lambda Function for the comparison
                    Func<float, float, bool> CompareSpeed;
                    if (isAscending){CompareSpeed = (x,y) => x <= y;}
                    else{CompareSpeed = (x,y) => x >= y;}
                    
                    float leftArgument;
                    float rightArgument;

                    switch(sortType)
                    {
                        case SortType.Atk:
                            leftArgument = left[indexLeft]._attackPower; 
                            rightArgument = right[indexRight]._attackPower; 
                            break;

                        case SortType.Def:
                            leftArgument = left[indexLeft]._defensePower; 
                            rightArgument = right[indexRight]._defensePower; 
                            break;

                        case SortType.Eva:
                            leftArgument = left[indexLeft]._dexterity; 
                            rightArgument = right[indexRight]._dexterity; 
                            break;

                        case SortType.Health:
                            leftArgument = left[indexLeft]._health; 
                            rightArgument = right[indexRight]._health; 
                            break;

                        case SortType.Speed:
                            leftArgument = left[indexLeft]._speed; 
                            rightArgument = right[indexRight]._speed; 
                            break;
                        
                        default:
                            leftArgument = 0;
                            rightArgument = 0;
                            break;
                    }
                    

                    //If item on left array is less than item on right array, add that item to the result array 
                    if (CompareSpeed(leftArgument, rightArgument))
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }                   
                }
                //if only the left array still has elements, add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }  
            }
            return result;
        }


        
    }