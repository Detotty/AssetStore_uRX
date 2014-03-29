/**
* Copyright (C) 2005-2014 by Rivello Multimedia Consulting (RMC).                    
* code [at] RivelloMultimediaConsulting [dot] com                                                  
*                                                                      
* Permission is hereby granted, free of charge, to any person obtaining
* a copy of this software and associated documentation files (the      
* "Software"), to deal in the Software without restriction, including  
* without limitation the rights to use, copy, modify, merge, publish,  
* distribute, sublicense, and#or sell copies of the Software, and to   
* permit persons to whom the Software is furnished to do so, subject to
* the following conditions:                                            
*                                                                      
* The above copyright notice and this permission notice shall be       
* included in all copies or substantial portions of the Software.      
*                                                                      
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,      
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF   
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
* IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR    
* OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
* ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
* OTHER DEALINGS IN THE SOFTWARE.                                      
*/
// Marks the right margin of code *******************************************************************


//--------------------------------------
//  Imports
//--------------------------------------
using UnityEngine;
using System.Collections;

//--------------------------------------
//  Namespace
//--------------------------------------
namespace com.rmc.projects.urx.mouse_double_click
{
	//--------------------------------------
	//  Namespace Properties
	//--------------------------------------
	//--------------------------------------
	//  Class Attributes
	//--------------------------------------
	//--------------------------------------
	//  Class
	//--------------------------------------
	public class MouseDoubleClickComponent_NonRX : MonoBehaviour
	{
		//--------------------------------------
		//  Properties
		//--------------------------------------
		// GETTER / SETTER

		// PUBLIC

		// PUBLIC STATIC
		/// <summary>
		/// MouseEvent Type
		/// </summary>
		public enum MouseEventType
		{
			DoubleClick
		}

		// PRIVATE

		/// <summary>
		/// KEEPING STATE: Timing information
		/// </summary>
		private int _state_clicksInLastXSeconds_int = 0;

		/// <summary>
		/// KEEPING STATE: Timing information
		/// </summary>
		private bool _wasLastEventTooRecent_boolean = false;



		// PRIVATE STATIC
		//--------------------------------------
		//  Methods
		//--------------------------------------
		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update ()
		{

			// VARIABLES
			int clicksRequiredForADoubleClick_int = 2;


			//
			if (Input.GetMouseButtonDown (0)) {

				if (!_wasLastEventTooRecent_boolean) {

					if (++_state_clicksInLastXSeconds_int >= clicksRequiredForADoubleClick_int) {

						//SUCCESS!
						_onMouseEvent (MouseEventType.DoubleClick);

						//STATE MANAGMENT
						_wasLastEventTooRecent_boolean = true;
						_state_clicksInLastXSeconds_int = 0;
						StartCoroutine ("DelayBetweenAllowingADoubleClick_Coroutine");
						StopCoroutine ("MaxTimeAllowedBetweenSingleCLicks_Coroutine");

					} else {

						//STATE MANAGMENT
						StartCoroutine ("MaxTimeAllowedBetweenSingleCLicks_Coroutine");
						StopCoroutine ("DelayBetweenAllowingADoubleClick_Coroutine");
					}
				}

			}	

		}

		//--------------------------------------
		//  Coroutines
		//--------------------------------------
		/// <summary>
		/// HANDLES TIMING: Between clicks
		/// </summary>
		private IEnumerator MaxTimeAllowedBetweenSingleCLicks_Coroutine ()
		{
			// VARIABLES
			float maxTimeAllowedBetweenSingleCLicks_float = 1;	

			// TIMING
			yield return new WaitForSeconds (maxTimeAllowedBetweenSingleCLicks_float);

			// STATE MANAGMENT
			_state_clicksInLastXSeconds_int = 0;
			
		}


		/// <summary>
		/// HANDLES TIMING: Between clicks
		/// </summary>
		private IEnumerator DelayBetweenAllowingADoubleClick_Coroutine ()
		{
			// VARIABLES
			float delayBetweenAllowingADoubleClick_float = 5;	

			// TIMING
			yield return new WaitForSeconds (delayBetweenAllowingADoubleClick_float);

			// STATE MANAGMENT
			_wasLastEventTooRecent_boolean = false;

			
		}


		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// _ons the mouse event.
		/// </summary>
		/// <param name="aMouseEventType">A mouse event type.</param>
		private void _onMouseEvent (MouseEventType aMouseEventType)
		{
			Debug.Log ("NonRX._onMouseDoubleClick() " + aMouseEventType);
		}
	}
}


