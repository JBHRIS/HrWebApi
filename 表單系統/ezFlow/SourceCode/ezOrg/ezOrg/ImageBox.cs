using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ezOrg {
	class ImageBox : Control {
		public delegate void LabelEditedEventHandler(object sender, System.EventArgs e);
		public event LabelEditedEventHandler LabelEdited;

		public static bool DrawLine = false;
		public static Control ParentControl = null;		
		public static float lineWidth = 1;
		public static Color lineColor = Color.Black;		
		public static int offsetX;
		public static int offsetY;

		private static ImageBox StartImage = null;
		private static Point oldMousePoint = Point.Empty;

		public object data1 = null;
		public object data2 = null;
		public object data3 = null;
		public PictureBox picturebox;
		public Label label;

		private TextBox textbox;
		private int moveX, moveY;
		private Arrow arrow;
		private Point arrowPoint;
		private bool CanMove;

		public Arrow NodeArrow {
			get { return arrow; }
		}

		public Point ArrowPoint {
			get {
				switch(arrow) {
					case Arrow.Up:
						arrowPoint = new Point(Width / 2, offsetY);
						break;
					case Arrow.Down:
						arrowPoint = new Point(Width / 2, Height - offsetY);
						break;
					case Arrow.Left:
						arrowPoint = new Point(offsetX, Height / 2);
						break;
					case Arrow.Right:
						arrowPoint = new Point(Width - offsetX, Height / 2);
						break;
					case Arrow.LeftUp:
						arrowPoint = new Point(offsetX, offsetY);
						break;
					case Arrow.LeftDown:
						arrowPoint = new Point(offsetX, Height - offsetY);
						break;
					case Arrow.RightUp:
						arrowPoint = new Point(Width - offsetX, offsetY);
						break;
					case Arrow.RightDown:
						arrowPoint = new Point(Width - offsetX, Height - offsetY);
						break;
					default:
						arrowPoint = Point.Empty;
						break;
				}

				if(arrowPoint != Point.Empty) arrowPoint.Offset(Left, Top);
				return arrowPoint;
			}
		}

		public Point GetPoint(Arrow ar) {
			Point p;
			switch(ar) {
				case Arrow.Up:
					p = new Point(Width / 2, offsetY);
					break;
				case Arrow.Down:
					p = new Point(Width / 2, Height - offsetY);
					break;
				case Arrow.Left:
					p = new Point(offsetX, Height / 2);
					break;
				case Arrow.Right:
					p = new Point(Width - offsetX, Height / 2);
					break;
				case Arrow.LeftUp:
					p = new Point(offsetX, offsetY);
					break;
				case Arrow.LeftDown:
					p = new Point(offsetX, Height - offsetY);
					break;
				case Arrow.RightUp:
					p = new Point(Width - offsetX, offsetY);
					break;
				case Arrow.RightDown:
					p = new Point(Width - offsetX, Height - offsetY);
					break;
				default:
					p = Point.Empty;
					break;
			}

			if(p != Point.Empty) p.Offset(Left, Top);
			return p;
		}

		protected virtual void OnLabelEdited(System.EventArgs e) {
			if(LabelEdited != null) {
				LabelEdited(this, e);
			}
		}

		public ImageBox(Image image, string text,bool move) {
			CanMove = move;

			arrow = Arrow.None;

			moveX = 0;
			moveY = 0;

			offsetX = 4;
			offsetY = 4;

			Text = text;

			picturebox = new PictureBox();
			picturebox.Width = image.Width;
			picturebox.Height = image.Height;
			picturebox.Top = 8;
			picturebox.Left = 8;
			picturebox.Image = image;
			picturebox.MouseDown += new MouseEventHandler(picturebox_MouseDown);
			picturebox.MouseMove += new MouseEventHandler(picturebox_MouseMove);
			this.Controls.Add(picturebox);

			label = new Label();
			label.AutoSize = true;
			label.Text = text;
			label.MouseDown += new MouseEventHandler(label_MouseDown);
			label.MouseMove += new MouseEventHandler(label_MouseMove);
			this.Controls.Add(label);
			label.Top = picturebox.Top + (picturebox.Height - label.Height) / 2;			
			label.Left = picturebox.Left + picturebox.Width;

			textbox = new TextBox();
			textbox.Text = text;
			textbox.Left = label.Left;
			textbox.Top = label.Top - 3;
			textbox.KeyDown += new KeyEventHandler(textbox_KeyDown);

			this.Width = picturebox.Width + picturebox.Left * 2 + label.Width;
			this.Height = picturebox.Height + picturebox.Top * 2;
		}

		void textbox_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Enter) {
				ChangeMode();
			}
		}

		protected override void OnKeyDown(KeyEventArgs e) {
			base.OnKeyDown(e);
			if(e.KeyCode == Keys.F2) {
				ChangeMode();
			}
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("確定刪除此節點？", "訊息通知",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					for(int i = ImageLink.ImageLinks.Count - 1; i >= 0; i--) {
						ImageLink imglink = ImageLink.ImageLinks[i];
						if(imglink.StartImage == this || imglink.EndImage == this) {
							imglink.ClearOldLine();
							ImageBox.ParentControl.Controls.Remove(imglink);
							ImageLink.ImageLinks.Remove(imglink);
						}
					}
					this.Controls.Clear();
					this.FindForm().ActiveControl = null;
					this.Parent.Controls.Remove(this);
					this.Dispose();
				}
			}
		}

		void label_MouseMove(object sender, MouseEventArgs e) {
			MouseEventArgs mouseE = new MouseEventArgs(e.Button, e.Clicks, e.X + label.Left, e.Y + label.Top, e.Delta);
			OnMouseMove(mouseE);
		}

		void picturebox_MouseMove(object sender, MouseEventArgs e) {
			MouseEventArgs mouseE = new MouseEventArgs(e.Button, e.Clicks, 
				e.X + picturebox.Left, e.Y + picturebox.Top, e.Delta);
			OnMouseMove(mouseE);
		}

		protected override void OnMouseMove(MouseEventArgs e) {			
			base.OnMouseMove(e);

			if(!CanMove) return;

			if(e.Button == MouseButtons.Left) {
				if(moveX > 0 && moveY > 0) {
					ImageBox.DrawLine = false;
					this.Left += e.X - moveX;
					this.Top += e.Y - moveY;
					ImageLink.ReDrawAll();
					return;					
				}
				else {
					moveX = e.X;
					moveY = e.Y;
				}
			}
			
			int udX = Width / 2 - offsetX;
			int muY = 0;
			int mdY = Height - offsetY * 2;

			if(e.X >= udX && e.X <= udX + offsetX * 2) {
				if(e.Y >= muY && e.Y <= muY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Green),
						Width / 2 - offsetX, 0, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Green);
					return;
				}
				if(e.Y >= mdY && e.Y <= mdY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Green),
						Width / 2 - offsetX, Height - offsetY * 2, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Green);
					return;
				}				
			}

			int lX = 0;
			int rX = Width - offsetX * 2;
			int lrY = Height / 2 - offsetY;

			if(e.Y >= lrY && e.Y <= lrY + offsetY * 2) {
				if(e.X >= lX && e.X <= lX + offsetX * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Green),
						0, Height / 2 - offsetY, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Green);
					return;
				}
				if(e.X >= rX && e.X <= rX + offsetX * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Green),
						Width - offsetX * 2, Height / 2 - offsetY, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Green);
					return;
				}				
			}

			int ludX = 0;
			int luY = 0;
			int ldY = Height - offsetY * 2;

			if(e.X >= ludX && e.X <= ludX + offsetX * 2) {
				if(e.Y >= luY && e.Y <= luY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Green),
						0, 0, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Green);
					return;
				}
				if(e.Y >= ldY && e.Y <= ldY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Green),
						0, Height - offsetY * 2, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Green);
					return;
				}				
			}

			int rudX = Width - offsetX * 2;
			int ruY = 0;
			int rdY = Height - offsetY * 2;

			if(e.X >= rudX && e.X <= rudX + offsetX * 2) {
				if(e.Y >= ruY && e.Y <= ruY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Green),
						Width - offsetX * 2, 0, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Green);
					return;
				}
				if(e.Y >= rdY && e.Y <= rdY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Green),
						Width - offsetX * 2, Height - offsetY * 2, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Green);
					return;
				}				
			}

			Draw(this.CreateGraphics());

			ImageBox.FormMouseMove(ParentControl, new MouseEventArgs(e.Button, e.Clicks, e.X + Left, e.Y + Top, e.Delta), 2, Color.Blue);
		}

		void label_MouseDown(object sender, MouseEventArgs e) {
			OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, e.X + label.Left, e.Y + label.Top, e.Delta));
		}

		void picturebox_MouseDown(object sender, MouseEventArgs e) {
			OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, e.X + picturebox.Left, e.Y + picturebox.Top, e.Delta));
		}		

		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);

			if(this.FindForm().ActiveControl != this) {
				this.FindForm().ActiveControl = this;
			}

			moveX = 0;
			moveY = 0;

			arrow = Arrow.None;

			if(e.Button == MouseButtons.Left) {
				if(!CanMove) return;

				int udX = Width / 2 - offsetX;
				int muY = 0;
				int mdY = Height - offsetY * 2;

				if(e.X >= udX && e.X <= udX + offsetX * 2) {
					if(e.Y >= muY && e.Y <= muY + offsetY * 2) arrow = Arrow.Up;
					if(e.Y >= mdY && e.Y <= mdY + offsetY * 2) arrow = Arrow.Down;					
				}

				int lX = 0;
				int rX = Width - offsetX * 2;
				int lrY = Height / 2 - offsetY;

				if(e.Y >= lrY && e.Y <= lrY + offsetY * 2) {
					if(e.X >= lX && e.X <= lX + offsetX * 2) arrow = Arrow.Left;
					if(e.X >= rX && e.X <= rX + offsetX * 2) arrow = Arrow.Right;					
				}

				int ludX = 0;
				int luY = 0;
				int ldY = Height - offsetY * 2;

				if(e.X >= ludX && e.X <= ludX + offsetX * 2) {
					if(e.Y >= luY && e.Y <= luY + offsetY * 2) arrow = Arrow.LeftUp;
					if(e.Y >= ldY && e.Y <= ldY + offsetY * 2) arrow = Arrow.LeftDown;					
				}

				int rudX = Width - offsetX * 2;
				int ruY = 0;
				int rdY = Height - offsetY * 2;

				if(e.X >= rudX && e.X <= rudX + offsetX * 2) {
					if(e.Y >= ruY && e.Y <= ruY + offsetY * 2) arrow = Arrow.RightUp;
					if(e.Y >= rdY && e.Y <= rdY + offsetY * 2) arrow = Arrow.RightDown;					
				}

				if(arrow != Arrow.None) {
					if(!ImageBox.DrawLine) {
						ImageBox.DrawLine = true;
						ImageBox.StartImage = this;
						ImageBox.oldMousePoint = Point.Empty;
					}
					else {
						if(ImageBox.StartImage != this) {							
							ImageBox.DrawLine = false;
							ImageBox.ClearOldLine();							
							ImageLink imglink = new ImageLink(ImageBox.StartImage, this,
								ImageBox.lineWidth, ImageBox.lineColor, LinkType.Standard);
							ImageBox.StartImage = null;
							ImageBox.oldMousePoint = Point.Empty;
							ImageBox.lineWidth = 1;
							ImageBox.lineColor = Color.Black;							
							ImageLink.ImageLinks.Add(imglink);
							ImageBox.ParentControl.Controls.Add(imglink);
						}
					}
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			Draw(e.Graphics);
		}

		private void Draw(Graphics g) {
			//上
			g.FillRectangle(new SolidBrush(Color.LightCyan),
				Width / 2 - offsetX, 0, offsetX * 2, offsetY * 2);
			//下
			g.FillRectangle(new SolidBrush(Color.LightCyan),
				Width / 2 - offsetX, Height - offsetY * 2, offsetX * 2, offsetY * 2);
			//左
			g.FillRectangle(new SolidBrush(Color.LightCyan),
				0, Height / 2 - offsetY, offsetX * 2, offsetY * 2);
			//右
			g.FillRectangle(new SolidBrush(Color.LightCyan),
				Width - offsetX * 2, Height / 2 - offsetY, offsetX * 2, offsetY * 2);
			//左上
			g.FillRectangle(new SolidBrush(Color.LightCyan),
				0, 0, offsetX * 2, offsetY * 2);
			//右上
			g.FillRectangle(new SolidBrush(Color.LightCyan),
				Width - offsetX * 2, 0, offsetX * 2, offsetY * 2);
			//左下
			g.FillRectangle(new SolidBrush(Color.LightCyan),
				0, Height - offsetY * 2, offsetX * 2, offsetY * 2);
			//右下
			g.FillRectangle(new SolidBrush(Color.LightCyan),
				Width - offsetX * 2, Height - offsetY * 2, offsetX * 2, offsetY * 2);

			if(this.FindForm().ActiveControl == this) {				
				g.DrawRectangle(new Pen(new SolidBrush(Color.Red), 2),
					offsetX, offsetY, Width - offsetX * 2 - 1, Height - offsetY * 2 - 1);
			}
			else {				
				g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2),
					offsetX, offsetY, Width - offsetX * 2 - 1, Height - offsetY * 2 - 1);
			}
		}

		private void ChangeMode() {
			if(!this.Controls.Contains(textbox)) {
				textbox.Width = label.Width;
				Text = label.Text;
				textbox.Clear();
				textbox.Text = Text;
				this.Controls.Remove(label);
				this.Controls.Add(textbox);
			}
			else {
				this.CreateGraphics().DrawRectangle(new Pen(new SolidBrush(Color.LightCyan), 2),
					offsetX, offsetY, Width - offsetX * 2 - 1, Height - offsetY * 2 - 1);
				Text = textbox.Text;
				label.Text = Text;
				this.Controls.Remove(textbox);
				this.Controls.Add(label);
				this.Width = picturebox.Width + picturebox.Left * 2 + label.Width;
				OnLabelEdited(EventArgs.Empty);
			}
			if(this.FindForm().ActiveControl == this) {
				this.CreateGraphics().DrawRectangle(new Pen(new SolidBrush(Color.Red), 2),
					offsetX, offsetY, Width - offsetX * 2 - 1, Height - offsetY * 2 - 1);
			}
			else {
				this.CreateGraphics().DrawRectangle(new Pen(new SolidBrush(Color.Black), 2),
					offsetX, offsetY, Width - offsetX * 2 - 1, Height - offsetY * 2 - 1);
			}
		}

		protected override void OnEnter(EventArgs e) {
			base.OnEnter(e);

			Draw(this.CreateGraphics());			
		}

		protected override void OnLeave(EventArgs e) {
			base.OnLeave(e);

			Draw(this.CreateGraphics());
		}

		public static void FormMouseMove(object sender, MouseEventArgs e,float width,Color color) {			
			ImageBox.lineWidth = width;
			ImageBox.lineColor = color;
			ImageLink.graphics = ImageBox.ParentControl.CreateGraphics();
			ClearOldLine();
			if(ImageBox.DrawLine) {
				ImageBox.ParentControl.CreateGraphics().DrawLine(new Pen(new SolidBrush(Color.Gray), width), 
					ImageBox.StartImage.ArrowPoint,e.Location);
				ImageBox.oldMousePoint = e.Location;
				ImageLink.ReDrawAll();
			}
		}

		public static void ClearOldLine() {
			if(ImageBox.oldMousePoint != Point.Empty) {
				ImageBox.ParentControl.CreateGraphics().DrawLine(new Pen(new SolidBrush(Color.LightCyan), ImageBox.lineWidth), 
					ImageBox.StartImage.ArrowPoint,ImageBox.oldMousePoint);
			}
		}

		public static void DrawOldLine(Color color) {
			if(ImageBox.oldMousePoint != Point.Empty) {
				ImageBox.ParentControl.CreateGraphics().DrawLine(new Pen(new SolidBrush(color), ImageBox.lineWidth),
					ImageBox.StartImage.ArrowPoint, ImageBox.oldMousePoint);
			}
		}		
	}
}