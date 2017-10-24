#region Copyright (c) IFS Research & Development
// ======================================================================================================
//
//                 IFS Research & Development
//
//  This program is protected by copyright law and by international
//  conventions. All licensing, renting, lending or copying (including
//  for private use), and all other use of the program, which is not
//  explicitly permitted by IFS, is a violation of the rights
//  of IFS. Such violations will be reported to the
//  appropriate authorities.
//
//  VIOLATIONS OF ANY COPYRIGHT IS PUNISHABLE BY LAW AND CAN LEAD
//  TO UP TO TWO YEARS OF IMPRISONMENT AND LIABILITY TO PAY DAMAGES.
// ======================================================================================================
#endregion
#region History
#endregion

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Appsrv;
using Ifs.Application.Enterp;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Accrul_
{
	
	/// <summary>
	/// </summary>
	public class cPictureListBoxResizableFin : VisPictureListBox, cResize.LateBind
	{
		// Multiple Inheritance: Base class instance.
		protected cResize _cResize;
		
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cPictureListBoxResizableFin()
		{
			// Initialize second-base instances.
			InitializeMultipleInheritance();
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cPictureListBoxResizableFin(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// Initialize second-base instances.
			InitializeMultipleInheritance();
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Multiple Inheritance Fields
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nRelativeOffsetUp
		{
			get { return _cResize.__nRelativeOffsetUp; }
			set { _cResize.__nRelativeOffsetUp = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nCurrentFormHeight
		{
			get { return _cResize.__nCurrentFormHeight; }
			set { _cResize.__nCurrentFormHeight = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nObjectOffsetDown
		{
			get { return _cResize.__nObjectOffsetDown; }
			set { _cResize.__nObjectOffsetDown = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nDesignHeight
		{
			get { return _cResize.__nDesignHeight; }
			set { _cResize.__nDesignHeight = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nAbsoluteOffsetRight
		{
			get { return _cResize.__nAbsoluteOffsetRight; }
			set { _cResize.__nAbsoluteOffsetRight = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nRelativeOffsetLeft
		{
			get { return _cResize.__nRelativeOffsetLeft; }
			set { _cResize.__nRelativeOffsetLeft = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalBoolean __bUseOldAlgorithmForTblOnTab
		{
			get { return _cResize.__bUseOldAlgorithmForTblOnTab; }
			set { _cResize.__bUseOldAlgorithmForTblOnTab = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nAbsoluteOffsetDown
		{
			get { return _cResize.__nAbsoluteOffsetDown; }
			set { _cResize.__nAbsoluteOffsetDown = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nDesignFormHeight
		{
			get { return _cResize.__nDesignFormHeight; }
			set { _cResize.__nDesignFormHeight = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nRelativeOffsetRight
		{
			get { return _cResize.__nRelativeOffsetRight; }
			set { _cResize.__nRelativeOffsetRight = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nAbsoluteOffsetLeft
		{
			get { return _cResize.__nAbsoluteOffsetLeft; }
			set { _cResize.__nAbsoluteOffsetLeft = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nAbsoluteOffsetUp
		{
			get { return _cResize.__nAbsoluteOffsetUp; }
			set { _cResize.__nAbsoluteOffsetUp = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nObjectOffsetRight
		{
			get { return _cResize.__nObjectOffsetRight; }
			set { _cResize.__nObjectOffsetRight = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nResizePropertiesUp
		{
			get { return _cResize.i_nResizePropertiesUp; }
			set { _cResize.i_nResizePropertiesUp = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nResizePropertiesLeft
		{
			get { return _cResize.i_nResizePropertiesLeft; }
			set { _cResize.i_nResizePropertiesLeft = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nDesignYPos
		{
			get { return _cResize.__nDesignYPos; }
			set { _cResize.__nDesignYPos = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nDesignXPos
		{
			get { return _cResize.__nDesignXPos; }
			set { _cResize.__nDesignXPos = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nDesignFormWidth
		{
			get { return _cResize.__nDesignFormWidth; }
			set { _cResize.__nDesignFormWidth = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nCurrentFormWidth
		{
			get { return _cResize.__nCurrentFormWidth; }
			set { _cResize.__nCurrentFormWidth = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nDesignWidth
		{
			get { return _cResize.__nDesignWidth; }
			set { _cResize.__nDesignWidth = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nObjectOffsetLeft
		{
			get { return _cResize.__nObjectOffsetLeft; }
			set { _cResize.__nObjectOffsetLeft = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nObjectOffsetUp
		{
			get { return _cResize.__nObjectOffsetUp; }
			set { _cResize.__nObjectOffsetUp = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber __nRelativeOffsetDown
		{
			get { return _cResize.__nRelativeOffsetDown; }
			set { _cResize.__nRelativeOffsetDown = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nResizePropertiesDown
		{
			get { return _cResize.i_nResizePropertiesDown; }
			set { _cResize.i_nResizePropertiesDown = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalNumber i_nResizePropertiesRight
		{
			get { return _cResize.i_nResizePropertiesRight; }
			set { _cResize.i_nResizePropertiesRight = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalBoolean __bResizeInitialized
		{
			get { return _cResize.__bResizeInitialized; }
			set { _cResize.__bResizeInitialized = value; }
		}
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalString p_sResizeChildObject
		{
			get { return _cResize.p_sResizeChildObject; }
			set { _cResize.p_sResizeChildObject = value; }
		}
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// cPictureListBoxResizableFin
			// 
			this.Name = "cPictureListBoxResizableFin";
			this.Font = new Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular);
			this.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.Sorted = true;
			this.Size = new System.Drawing.Size(72, 72);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber ResizePropertyExtract()
		{
			#region Actions
			using (new SalContext(this))
			{
				return true;
			}
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Methods
		
		/// <summary>
		/// The ResizeChangePosAndSize function moves and resizes an object.
		/// </summary>
		/// <param name="nDiffX">
		/// Horizontal move
		/// Number of pixels to move the horizontal position of object. Specify negative values to move
		/// left, positive values to move right.
		/// </param>
		/// <param name="nDiffY">
		/// Vertical move
		/// Number of pixels to move the vertical position of object. Specify negative values to move
		/// up, positive values to move down.
		/// </param>
		/// <param name="nDiffWidth">
		/// With chnage
		/// Number of pixels to change the width of object. Specify negative values to decrease, positive to increase.
		/// </param>
		/// <param name="nDiffHeight">
		/// Height chnage
		/// Number of pixels to change the height of object. Specify negative values to decrease, positive to increase.
		/// </param>
		/// <param name="bRepaint">
		/// Repaint flag
		/// Specify TRUE to move/size the objecct immediately and repaint the window. If FALSE is specified, the move
		/// and repaint will take place the next time the window is resized.
		/// </param>
		/// <returns></returns>
		public virtual SalNumber ResizeChangePosAndSize(SalNumber nDiffX, SalNumber nDiffY, SalNumber nDiffWidth, SalNumber nDiffHeight, SalBoolean bRepaint)
		{
			using (new SalContext(this))
			{
				return _cResize.ResizeChangePosAndSize(nDiffX, nDiffY, nDiffWidth, nDiffHeight, bRepaint);
			}
		}
		
		/// <summary>
		/// The ResizePropertiesSet function sets the properties that control
		/// how an object is resized.
		/// COMMENTS:
		/// For framework objects, applications should use Foundation1 properties
		/// to specify resize properties. However, for application-specific object,
		/// it might be neccessary to call the ResizePropertiesSet function.
		/// </summary>
		/// <param name="nPropertyLeft">
		/// Left edge
		/// Controls how the left edge of the object is repositioned when the window size changes. Specify
		/// any of the RESIZE_* constants.
		/// </param>
		/// <param name="nPropertyUp">
		/// Upper edge
		/// Controls how the upper edge of the object is repositioned when the window size changes. Specify
		/// any of the RESIZE_* constants.
		/// </param>
		/// <param name="nPropertyRight">
		/// Right edge
		/// Controls how the right edge of the object is repositioned when the window size changes. Specify
		/// any of the RESIZE_* constants.
		/// </param>
		/// <param name="nPropertyDown">
		/// Bottom edge
		/// Controls how the bottom edge of the object is repositioned when the window size changes. Specify
		/// any of the RESIZE_* constants.
		/// 
		/// RESIZE Constants
		/// RESIZE_FixedLeft - Keep constant distance to the left border,
		/// RESIZE_FixedUp - Keep constant distance to the top border,
		/// RESIZE_FixedRight - Keep a constant distance to the right border,
		/// RESIZE_FixedDown - Keep a constant distance to the bottom border,
		/// RESIZE_Relative - Keep a relative distance to the border,
		/// RESIZE_FillOut - Tail to the border,
		/// RESIZE_FillOutMargin - Tail to the border but leave a margin,
		/// </param>
		/// <returns></returns>
		public virtual SalNumber ResizePropertiesSet(SalNumber nPropertyLeft, SalNumber nPropertyUp, SalNumber nPropertyRight, SalNumber nPropertyDown)
		{
			using (new SalContext(this))
			{
				return _cResize.ResizePropertiesSet(nPropertyLeft, nPropertyUp, nPropertyRight, nPropertyDown);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nX"></param>
		/// <param name="nY"></param>
		/// <param name="nWidth"></param>
		/// <param name="nHeight"></param>
		/// <returns></returns>
		public virtual SalNumber _ResizeChildObjects(SalNumber nX, SalNumber nY, SalNumber nWidth, SalNumber nHeight)
		{
			using (new SalContext(this))
			{
				return _cResize._ResizeChildObjects(nX, nY, nWidth, nHeight);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nLeft"></param>
		/// <param name="nRight"></param>
		/// <param name="nUp"></param>
		/// <param name="nDown"></param>
		/// <returns></returns>
		public virtual SalNumber _ResizeObjectOffset(ref SalNumber nLeft, ref SalNumber nRight, ref SalNumber nUp, ref SalNumber nDown)
		{
			using (new SalContext(this))
			{
				return _cResize._ResizeObjectOffset(ref nLeft, ref nRight, ref nUp, ref nDown);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nProperty"></param>
		/// <returns></returns>
		public virtual SalNumber _ResizePropertyDecode(SalNumber nProperty)
		{
			using (new SalContext(this))
			{
				return _cResize._ResizePropertyDecode(nProperty);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nFrameWidth"></param>
		/// <param name="nFrameHeight"></param>
		/// <returns></returns>
		public virtual SalNumber __ResizeAdjustSize(SalNumber nFrameWidth, SalNumber nFrameHeight)
		{
			using (new SalContext(this))
			{
				return _cResize.__ResizeAdjustSize(nFrameWidth, nFrameHeight);
			}
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hWndParent"></param>
		/// <param name="nFrameWidth"></param>
		/// <param name="nFrameHeight"></param>
		/// <returns></returns>
		public virtual SalBoolean __ResizeInit(SalWindowHandle hWndParent, SalNumber nFrameWidth, SalNumber nFrameHeight)
		{
			using (new SalContext(this))
			{
				return _cResize.__ResizeInit(hWndParent, nFrameWidth, nFrameHeight);
			}
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cPictureListBoxResizableFin to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cPictureListBoxResizableFin self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cPictureListBoxResizableFin.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cPictureListBoxResizableFin(cResize super)
		{
			return ((cPictureListBoxResizableFin)super._derived);
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Multiple Inheritance: Initialize delegate instances.
		/// </summary>
		private void InitializeMultipleInheritance()
		{
			this._cResize = new cResize(this);
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public static cPictureListBoxResizableFin FromHandle(SalWindowHandle handle)
		{
			return ((cPictureListBoxResizableFin)SalWindow.FromHandle(handle, typeof(cPictureListBoxResizableFin)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalBoolean vrtResizePropertyExtract()
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.ResizePropertyExtract();
			}
			else
			{
				return lateBind.vrtResizePropertyExtract();
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalNumber vrt_ResizeChildObjects(SalNumber nX, SalNumber nY, SalNumber nWidth, SalNumber nHeight)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this._ResizeChildObjects(nX, nY, nWidth, nHeight);
			}
			else
			{
				return lateBind.vrt_ResizeChildObjects(nX, nY, nWidth, nHeight);
			}
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public virtual SalNumber vrt_ResizeObjectOffset(ref SalNumber nLeft, ref SalNumber nRight, ref SalNumber nUp, ref SalNumber nDown)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this._ResizeObjectOffset(ref nLeft, ref nRight, ref nUp, ref nDown);
			}
			else
			{
				return lateBind.vrt_ResizeObjectOffset(ref nLeft, ref nRight, ref nUp, ref nDown);
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalBoolean vrtResizePropertyExtract();
			SalNumber vrt_ResizeChildObjects(SalNumber nX, SalNumber nY, SalNumber nWidth, SalNumber nHeight);
			SalNumber vrt_ResizeObjectOffset(ref SalNumber nLeft, ref SalNumber nRight, ref SalNumber nUp, ref SalNumber nDown);
		}
		#endregion
	}
}
