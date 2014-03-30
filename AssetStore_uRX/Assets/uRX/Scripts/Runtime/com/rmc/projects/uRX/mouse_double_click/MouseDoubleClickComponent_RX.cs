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
using com.tinylabproductions.TLPLib.Reactive;

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
	public class MouseDoubleClickComponent_RX : MonoBehaviour
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

		// PRIVATE STATIC

		//--------------------------------------
		//  Methods
		//--------------------------------------
		///<summary>
		///	Use this for initialization
		///</summary>
		void Start ()
		{
			// VARIABLES
			float maxTimeAllowedBetweenSingleCLicks_float = 1;
			float delayBetweenAllowingADoubleClick_float = 5;	
			int clicksRequiredForADoubleClick_int = 2;
			
			// CREATE OBSERVABLE 
			//(ORDER IS NOT IMPORTANT, BUT SUBSCRIBE MUST BE LAST)
			var mouseDoubleClickObservable = Observable

				//RUN IT EVERY FRAME (INTERNALLY THAT MEANS Update()
				.everyFrame

				//FILTER RESULTS OF THE FRAME
				//WE CARE ONLY 'DID USER CLICK MOUSE BUTTON?'
				.filter	(
					_ => 
					Input.GetMouseButtonDown (0)
				)

				//DID WE FIND X RESULTS WITHIN Y SECONDS?
				.withinTimeframe (clicksRequiredForADoubleClick_int, maxTimeAllowedBetweenSingleCLicks_float)

				//REQUIRE SOME 'COOL-DOWN-TIME' BETWEEN SUCCESSES
				.onceEvery (delayBetweenAllowingADoubleClick_float);


			//FOR EVERY EVENT THAT MEETS THOSE CRITERIA, CALL A METHOD
			var subscription = mouseDoubleClickObservable
				.subscribe (
					_ => 
					_onMouseEvent (MouseEventType.DoubleClick)

				);


			Debug.Log ("Subscription Setup : " + subscription);


		}
		//--------------------------------------
		//  Events
		//--------------------------------------
		/// <summary>
		/// SUCCESS: Double click
		/// </summary>
		private void _onMouseEvent (MouseEventType aMouseEventType)
		{

				Debug.Log ("RX._onMouseDoubleClick() " + aMouseEventType);
		}
	}
}


