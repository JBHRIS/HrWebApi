using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ezOrg {	
	class ImageLink : Control {
		public static List<ImageLink> ImageLinks = new List<ImageLink>();
		public static Graphics graphics;
		public static int defaultLength = 40;

		public delegate void LabelEditedEventHandler(object sender, System.EventArgs e);
		public event LabelEditedEventHandler LabelEdited;

		public object data = null;

		private Label label;
		private TextBox textbox;
		private Point newStartPoint, newEndPoint;
		private Point oldStartPoint, oldEndPoint;
		private Color lineColor;
		private LinkType newlinktype,oldlinktype;
		private float lineWidth;		
		private ImageBox startImage, endImage;
		private Arrow startImageArrow, endImageArrow;
		private Point newComStartPoint, newComEndPoint;
		private Point oldComStartPoint, oldComEndPoint;		

		public ImageBox StartImage {
			get {
				return startImage;
			}
		}

		public ImageBox EndImage {
			get {
				return endImage;
			}
		}

		protected virtual void OnLabelEdited(System.EventArgs e) {
			if(LabelEdited != null) {
				LabelEdited(this, e);
			}
		}

		private void Init(ImageBox start, ImageBox end, float width, Color color, LinkType type,string text) {
			ImageLink.ImageLinks.Add(this);

			ImageLink.graphics = ImageBox.ParentControl.CreateGraphics();

			newlinktype = type;
			oldlinktype = newlinktype;
			startImage = start;
			endImage = end;

			LinkMargin();

			oldStartPoint = newStartPoint;
			oldEndPoint = newEndPoint;

			newComStartPoint = startImage.GetPoint(startImageArrow);
			newComEndPoint = endImage.GetPoint(endImageArrow);
			oldComStartPoint = newComStartPoint;
			oldComEndPoint = newComEndPoint;

			lineWidth = width;
			lineColor = color;
			
			label = new Label();
			label.AutoSize = true;
			label.Text = text;
			label.MouseDown += new MouseEventHandler(label_MouseDown);
			label.MouseMove += new MouseEventHandler(label_MouseMove);
			this.Controls.Add(label);

			if(label.Text.Trim().Length > 0) {
				this.Width = label.Width + 4;
				this.Height = 24;
			}
			else {
				this.Width = 0;
				this.Height = 0;
			}

			label.Left = (this.Width - label.Width) / 2;
			label.Top = (this.Height - label.Height) / 2;

			textbox = new TextBox();
			textbox.Width = this.Width - 2;
			textbox.Left = 1;
			textbox.Top = 1;
			textbox.KeyDown += new KeyEventHandler(textbox_KeyDown);
		}

		public ImageLink(ImageBox start, ImageBox end, float width, Color color,LinkType type) {
			startImageArrow = start.NodeArrow;
			endImageArrow = end.NodeArrow;
			Init(start, end, width, color, type, "Label");
		}

		public ImageLink(ImageBox start, ImageBox end,Arrow startArrow,Arrow endArrow, float width, Color color, LinkType type,string text) {
			startImageArrow = startArrow;
			endImageArrow = endArrow;

			Init(start, end, width, color, type, text);
		}

		void label_MouseMove(object sender, MouseEventArgs e) {
			OnMouseMove(new MouseEventArgs(e.Button, e.Clicks, e.X + label.Left, e.Y + label.Top, e.Delta));
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			base.OnMouseMove(e);

			ImageBox.FormMouseMove(ImageBox.ParentControl, 
				new MouseEventArgs(e.Button, e.Clicks, e.X + Left, e.Y + Top, e.Delta), lineWidth, lineColor);
		}

		void label_MouseDown(object sender, MouseEventArgs e) {
			OnMouseDown(e);
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);
			if(e.Button == MouseButtons.Left) {
				if(this.FindForm().ActiveControl != this) {
					this.FindForm().ActiveControl = this;
				}
			}
			if(e.Button == MouseButtons.Right) {
				this.ContextMenuStrip = new ContextMenuStrip();
				this.ContextMenuStrip.Items.Add("置中連接", null, new EventHandler(StandardLink));
				this.ContextMenuStrip.Items.Add("靠近起點", null, new EventHandler(NearStartLink));
				this.ContextMenuStrip.Items.Add("靠近終點", null, new EventHandler(NearEndLink));
			}
		}

		void StandardLink(object sender, EventArgs e) {
			oldlinktype = newlinktype;
			newlinktype = LinkType.Standard;
			ImageLink.ReDrawAll();
		}

		void NearStartLink(object sender, EventArgs e) {
			oldlinktype = newlinktype;
			newlinktype = LinkType.NearStart;
			ImageLink.ReDrawAll();		
		}

		void NearEndLink(object sender, EventArgs e) {
			oldlinktype = newlinktype;
			newlinktype = LinkType.NearEnd;
			ImageLink.ReDrawAll();
		}

		void textbox_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Enter) {
				ChangeMode();
			}
			if(e.KeyCode == Keys.F2) {
				OnKeyDown(e);
			}
		}

		private void ChangeMode() {
			if(!this.Controls.Contains(textbox)) {
				textbox.Width = this.Width - 2;
				Text = label.Text;
				textbox.Clear();
				textbox.Text = Text;
				this.Controls.Remove(label);
				this.Controls.Add(textbox);
			}
			else {
				this.CreateGraphics().DrawRectangle(new Pen(new SolidBrush(ImageBox.ParentControl.BackColor), 1),
					0, 0, Width - 1, Height - 1);
				Text = textbox.Text;
				label.Text = Text;
				this.Controls.Remove(textbox);
				this.Controls.Add(label);
				this.Width = label.Width + 4;
				this.Height = 24;
				if(label.Text == "") {
					this.Width = 0;
					this.Height = 0;
				}
				label.Left = (this.Width - label.Width) / 2;
				label.Top = (this.Height - label.Height) / 2;				
				OnLabelEdited(EventArgs.Empty);
			}
		}

		protected override void OnKeyDown(KeyEventArgs e) {
			base.OnKeyDown(e);

			if(e.KeyCode == Keys.F2) {
				ChangeMode();
			}
		}

		private void DrawBorder() {
			if(this.Width > 0 && this.Height > 0) {
				if(this.FindForm().ActiveControl == this)
					this.CreateGraphics().DrawRectangle(new Pen(new SolidBrush(Color.Red), 1),
						0, 0, Width - 1, Height - 1);
				else
					this.CreateGraphics().DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1),
						0, 0, Width - 1, Height - 1);
			}
		}

		protected override void OnEnter(EventArgs e) {
			base.OnEnter(e);
			DrawBorder();
		}

		protected override void OnLeave(EventArgs e) {
			base.OnLeave(e);
			DrawBorder();
		}

		protected override void OnPaint(PaintEventArgs e) {			
			base.OnPaint(e);			
			DrawLine();
		}

		public void PrintDrawLine(Graphics g) {
			Graphics gBak = graphics;
			graphics = g;
			DynamicLine(lineColor, newStartPoint, newEndPoint, newlinktype);
			if(startImageArrow == Arrow.Up || startImageArrow == Arrow.Down ||
				startImageArrow == Arrow.Left || startImageArrow == Arrow.Right) {
				ImageLink.graphics.DrawLine(new Pen(new SolidBrush(lineColor), lineWidth), newComStartPoint, newStartPoint);
			}
			if(endImageArrow == Arrow.Up || endImageArrow == Arrow.Down ||
				endImageArrow == Arrow.Left || endImageArrow == Arrow.Right) {
				DrawLineWithCap(lineColor, newEndPoint, newComEndPoint);
			}
			graphics = gBak;
		}

		private void DrawLine() {
			ClearOldLine();
			ResetXY();
			DynamicLine(lineColor, newStartPoint, newEndPoint,newlinktype);
			if(startImageArrow == Arrow.Up || startImageArrow == Arrow.Down ||
				startImageArrow == Arrow.Left || startImageArrow == Arrow.Right) {
				ImageLink.graphics.DrawLine(new Pen(new SolidBrush(lineColor), lineWidth), newComStartPoint, newStartPoint);
			}
			if(endImageArrow == Arrow.Up || endImageArrow == Arrow.Down ||
				endImageArrow == Arrow.Left || endImageArrow == Arrow.Right) {				
				DrawLineWithCap(lineColor, newEndPoint, newComEndPoint);
			}
			DrawBorder();
		}

		private void DrawLineWithCap(Color color, Point start, Point end) {
			GraphicsPath hPath = new GraphicsPath();
			hPath.AddLine(new Point(0, -3), new Point(2, -8));
			hPath.AddLine(new Point(0, -6), new Point(2, -8));
			hPath.AddLine(new Point(0, -3), new Point(-2, -8));
			hPath.AddLine(new Point(0, -6), new Point(-2, -8));
			CustomLineCap HookCap = new CustomLineCap(null, hPath);
			Pen customCapPen = new Pen(color, lineWidth);
			customCapPen.CustomEndCap = HookCap;
			ImageLink.graphics.DrawLine(customCapPen, start, end);
		}

		void DynamicLine(Color color,Point Start,Point End,LinkType linktype) {
			if(startImageArrow == Arrow.LeftUp || startImageArrow == Arrow.LeftDown ||
				startImageArrow == Arrow.RightUp || startImageArrow == Arrow.RightDown ||
				endImageArrow == Arrow.LeftUp || endImageArrow == Arrow.LeftDown ||
				endImageArrow == Arrow.RightUp || endImageArrow == Arrow.RightDown) {
				DrawLineWithCap(color, Start, End);				
			}
			else {
				switch(startImageArrow) {
					case Arrow.Up:
					case Arrow.Down:
						switch(endImageArrow) {
							case Arrow.Up:
							case Arrow.Down:
								if(startImageArrow == endImageArrow) {
									switch(linktype) {
										case LinkType.Standard:
											ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
											break;
										default:
											if(Start.Y == End.Y || Start.X == End.X) {
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
											}
											else if((startImageArrow == Arrow.Up && Start.Y < End.Y) ||
												(startImageArrow == Arrow.Down && Start.Y > End.Y)) {
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
													new Point(End.X, Start.Y));
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(End.X, Start.Y), End);
											}
											else {
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
													new Point(Start.X, End.Y));
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(Start.X, End.Y), End);
											}
											break;
									}
								}
								else {
									switch(linktype) {
										case LinkType.Standard:
											ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
											break;
										default:
											if(Start.Y == End.Y || Start.X == End.X) {
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
											}
											else if((startImageArrow == Arrow.Up && Start.Y < End.Y) ||
												(startImageArrow == Arrow.Down && Start.Y > End.Y)) {
												int centerX = 0;
												if(Start.X < End.X) {
													centerX = Start.X + Math.Abs((Start.X - End.X) / 2);
												}
												else {
													centerX = Start.X - Math.Abs((Start.X - End.X) / 2);
												}
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
													new Point(centerX, Start.Y));
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth),
													new Point(centerX, Start.Y),
													new Point(centerX, End.Y));
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(centerX, End.Y), End);
											}
											else {
												if(linktype == LinkType.NearStart) {
													ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
														new Point(End.X, Start.Y));
													ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(End.X, Start.Y), End);
												}
												else {
													ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
														new Point(Start.X, End.Y));
													ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(Start.X, End.Y), End);
												}
											}
											break;
									}
								}
								break;
							case Arrow.Left:
							case Arrow.Right:
								switch(linktype) {
									case LinkType.NearStart:
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
											new Point(End.X, Start.Y));
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth),
											new Point(End.X, Start.Y), End);
										break;
									case LinkType.NearEnd:
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
											new Point(Start.X, End.Y));
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth),
											new Point(Start.X, End.Y), End);
										break;
									default:
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
										break;
								}
								break;
						}
						break;
					case Arrow.Left:
					case Arrow.Right:
						switch(endImageArrow) {
							case Arrow.Left:
							case Arrow.Right:
								if(startImageArrow == endImageArrow) {
									switch(linktype) {
										case LinkType.Standard:
											ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
											break;
										default:
											if(Start.Y == End.Y || Start.X == End.X) {
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
											}
											else if((startImageArrow == Arrow.Left && Start.X < End.X) ||
													(startImageArrow == Arrow.Right && Start.X > End.X)) {
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
													new Point(Start.X, End.Y));
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(Start.X, End.Y), End);
											}
											else {
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
													new Point(End.X, Start.Y));
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(End.X, Start.Y), End);
											}
											break;
									}
								}
								else {
									switch(linktype) {
										case LinkType.Standard:
											ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
											break;
										default:
											if(Start.Y == End.Y || Start.X == End.X) {
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
											}
											else if((startImageArrow == Arrow.Left && Start.X < End.X) ||
												(startImageArrow == Arrow.Right && Start.X > End.X)) {
												int centerY = 0;
												if(Start.Y < End.Y) {
													centerY = Start.Y + Math.Abs((Start.Y - End.Y) / 2);
												}
												else {
													centerY = Start.Y - Math.Abs((Start.Y - End.Y) / 2);
												}
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
													new Point(Start.X, centerY));
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth),
													new Point(Start.X, centerY),
													new Point(End.X, centerY));
												ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(End.X, centerY), End);
											}
											else {
												if(linktype == LinkType.NearStart) {
													ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
														new Point(Start.X, End.Y));
													ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(Start.X, End.Y), End);
												}
												else {
													ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
														new Point(End.X, Start.Y));
													ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), new Point(End.X, Start.Y), End);
												}
											}
											break;
									}
								}
								break;
							case Arrow.Up:
							case Arrow.Down:
								switch(linktype) {
									case LinkType.NearStart:
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
											new Point(Start.X, End.Y));
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth),
											new Point(Start.X, End.Y), End);
										break;
									case LinkType.NearEnd:
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start,
											new Point(End.X, Start.Y));
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth),
											new Point(End.X, Start.Y), End);
										break;
									default:
										ImageLink.graphics.DrawLine(new Pen(new SolidBrush(color), lineWidth), Start, End);
										break;
								}
								break;
						}
						break;
				}
			}
		}

		private void ResetXY() {
			int minX = (newStartPoint.X < newEndPoint.X) ? newStartPoint.X : newEndPoint.X;
			int minY = (newStartPoint.Y < newEndPoint.Y) ? newStartPoint.Y : newEndPoint.Y;
			int centerX = minX + Math.Abs((newStartPoint.X - newEndPoint.X) / 2);
			int centerY = minY + Math.Abs((newStartPoint.Y - newEndPoint.Y) / 2);

			if((startImageArrow == Arrow.LeftUp || startImageArrow == Arrow.LeftDown ||
				startImageArrow == Arrow.RightUp || startImageArrow == Arrow.RightDown) &&
				(endImageArrow == Arrow.LeftUp || endImageArrow == Arrow.LeftDown ||
				endImageArrow == Arrow.RightUp || endImageArrow == Arrow.RightDown)) {
				this.Top = centerY - label.Height / 2 - label.Top;
				this.Left = centerX - label.Width / 2 - label.Left;
			}
			else {
				switch(newlinktype) {
					case LinkType.NearStart:
						switch(startImageArrow) {
							case Arrow.Up:
							case Arrow.Down:
								this.Top = newStartPoint.Y - label.Height / 2 - label.Top;
								this.Left = newStartPoint.X - label.Width / 2 - label.Left;
								break;
							case Arrow.Left:
								this.Top = newStartPoint.Y - label.Height / 2 - label.Top;
								this.Left = (newStartPoint.X - label.Width) + ImageLink.defaultLength / 2;
								break;
							case Arrow.Right:
								this.Top = newStartPoint.Y - label.Height / 2 - label.Top;
								this.Left = (newStartPoint.X - ImageLink.defaultLength / 2);
								break;
							default:
								this.Top = centerY - label.Height / 2 - label.Top;
								this.Left = centerX - label.Width / 2 - label.Left;
								break;
						}
						break;
					case LinkType.NearEnd:
						switch(endImageArrow) {
							case Arrow.Up:
							case Arrow.Down:
								this.Top = newEndPoint.Y - label.Height / 2 - label.Top;
								this.Left = newEndPoint.X - label.Width / 2 - label.Left;								
								break;
							case Arrow.Left:
								this.Top = newEndPoint.Y - label.Height / 2 - label.Top;
								this.Left = (newEndPoint.X - label.Width) + 10;
								break;
							case Arrow.Right:
								this.Top = newEndPoint.Y - label.Height / 2 - label.Top;
								this.Left = (newEndPoint.X - 10);
								break;
							default:
								this.Top = centerY - label.Height / 2 - label.Top;
								this.Left = centerX - label.Width / 2 - label.Left;
								break;
						}
						break;
					default:
						this.Top = centerY - label.Height / 2 - label.Top;
						this.Left = centerX - label.Width / 2 - label.Left;
						break;
				}
			}
		}

		public void MoveLine() {
			if(startImage != null && endImage != null) {
				oldStartPoint = newStartPoint;
				oldEndPoint = newEndPoint;

				LinkMargin();

				oldComStartPoint = newComStartPoint;
				oldComEndPoint = newComEndPoint;

				newComStartPoint = startImage.GetPoint(startImageArrow);
				newComEndPoint = endImage.GetPoint(endImageArrow);

				DrawLine();

				oldlinktype = newlinktype;
			}
		}

		public static void ReDrawAll() {
			ImageLink.graphics = ImageBox.ParentControl.CreateGraphics();
			for(int i=0; i<ImageLink.ImageLinks.Count; i++) {
				ImageLink.ImageLinks[i].MoveLine();
			}
		}

		public void ClearOldLine() {			
			DynamicLine(ImageBox.ParentControl.BackColor, oldStartPoint, oldEndPoint, oldlinktype);			
			if(startImageArrow == Arrow.Up || startImageArrow == Arrow.Down ||
				startImageArrow == Arrow.Left || startImageArrow == Arrow.Right) {
				ImageLink.graphics.DrawLine(new Pen(new SolidBrush(ImageBox.ParentControl.BackColor), lineWidth), oldComStartPoint, oldStartPoint);
			}
			if(endImageArrow == Arrow.Up || endImageArrow == Arrow.Down ||
				endImageArrow == Arrow.Left || endImageArrow == Arrow.Right) {
				DrawLineWithCap(ImageBox.ParentControl.BackColor, oldEndPoint, oldComEndPoint);
			}
		}

		private void LinkMargin() {
			switch(startImageArrow) {
				case Arrow.Up:
					newStartPoint = new Point(startImage.GetPoint(startImageArrow).X,
						startImage.GetPoint(startImageArrow).Y - ImageLink.defaultLength);
					break;
				case Arrow.Down:
					newStartPoint = new Point(startImage.GetPoint(startImageArrow).X,
						startImage.GetPoint(startImageArrow).Y + ImageLink.defaultLength);
					break;
				case Arrow.Left:
					newStartPoint = new Point(startImage.GetPoint(startImageArrow).X - ImageLink.defaultLength,
						startImage.GetPoint(startImageArrow).Y);
					break;
				case Arrow.Right:
					newStartPoint = new Point(startImage.GetPoint(startImageArrow).X + ImageLink.defaultLength,
						startImage.GetPoint(startImageArrow).Y);
					break;
				default:
					newStartPoint = startImage.GetPoint(startImageArrow);
					break;
			}
			switch(endImageArrow) {
				case Arrow.Up:
					newEndPoint = new Point(endImage.GetPoint(endImageArrow).X,
						endImage.GetPoint(endImageArrow).Y - ImageLink.defaultLength);
					break;
				case Arrow.Down:
					newEndPoint = new Point(endImage.GetPoint(endImageArrow).X,
						endImage.GetPoint(endImageArrow).Y + ImageLink.defaultLength);
					break;
				case Arrow.Left:
					newEndPoint = new Point(endImage.GetPoint(endImageArrow).X - ImageLink.defaultLength,
						endImage.GetPoint(endImageArrow).Y);
					break;
				case Arrow.Right:
					newEndPoint = new Point(endImage.GetPoint(endImageArrow).X + ImageLink.defaultLength,
						endImage.GetPoint(endImageArrow).Y);
					break;
				default:
					newEndPoint = endImage.GetPoint(endImageArrow);
					break;
			}
		}
	}
}
