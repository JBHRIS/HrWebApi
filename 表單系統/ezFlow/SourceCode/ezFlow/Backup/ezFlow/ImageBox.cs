using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ezFlow {
	class ImageBox : Control {
		public delegate void LabelEditedEventHandler(object sender, System.EventArgs e);
		public event LabelEditedEventHandler LabelEdited;
		public delegate void LinkLabelEditedEventHandler(object sender, System.EventArgs e);
		public event LinkLabelEditedEventHandler LinkLabelEdited;
		public delegate void LinkFinishedEventHandler(object sender, MouseEventArgs e);
		public event LinkFinishedEventHandler LinkFinished;
		public delegate void LinkCancelEventHandler(object sender, System.EventArgs e);
		public event LinkCancelEventHandler LinkCancel;
		public delegate void ImageDeletingEventHandler(object sender, System.EventArgs e);
		public event ImageDeletingEventHandler ImageDeleting;
		public delegate void LinkContentEventHandler(object sender,System.EventArgs e);
		public event LinkContentEventHandler LinkContent;
		public delegate void ImageContentEventHandler(object sender, System.EventArgs e);
		public event ImageContentEventHandler ImageContent;
		public delegate void LinkDeleteHandler(object sender,System.EventArgs e);
		public event LinkDeleteHandler LinkDelete;

		public static bool DrawLine = false;		
		public static float lineWidth;
		public static Color lineColor;
		public static int offsetX;
		public static int offsetY;

		private static ImageBox StartImage = null;
		private static Point oldMousePoint = Point.Empty;

		public object data1 = null;
		public object data2 = null;
		public object data3 = null;
		public PictureBox picturebox;
		public Label label;
		public Control ParentControl = null;

		private TextBox textbox;
		private int moveX, moveY;
		public Arrow arrow;
		private Point arrowPoint;
		private bool CanMove;
		private ImageLink eventImageLink = null;

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

		protected virtual void OnLinkDelete(System.EventArgs e) {
			if(LinkDelete != null) {
				LinkDelete(eventImageLink, e);
			}
		}

		protected virtual void OnImageContent(System.EventArgs e) {
			if(ImageContent != null) {
				ImageContent(this, e);
			}
		}

		protected virtual void OnLinkContent(System.EventArgs e) {
			if(LinkContent != null) {
				LinkContent(eventImageLink, e);
			}
		}

		protected virtual void OnLinkLabelEdited(System.EventArgs e) {
			if(LinkLabelEdited != null) {
				LinkLabelEdited(eventImageLink, e);
			}
		}

		protected virtual void OnLabelEdited(System.EventArgs e) {
			if(LabelEdited != null) {
				LabelEdited(this, e);
			}
		}

		protected virtual void OnLinkFinished(MouseEventArgs e) {
			if(LinkFinished != null) {
				LinkFinished(eventImageLink, e);
			}
		}

		protected virtual void OnLinkCancel(System.EventArgs e) {
			if(LinkCancel != null) {
				LinkCancel(eventImageLink, e);
			}
		}

		protected virtual void OnImageDeleting(System.EventArgs e) {
			if(ImageDeleting != null) {
				ImageDeleting(this, e);
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
			picturebox.MouseUp += new MouseEventHandler(picturebox_MouseUp);
			this.Controls.Add(picturebox);

			label = new Label();
			label.AutoSize = true;
			label.Text = text;
			label.MouseDown += new MouseEventHandler(label_MouseDown);
			label.MouseMove += new MouseEventHandler(label_MouseMove);
			label.MouseUp += new MouseEventHandler(label_MouseUp);
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

		void picturebox_MouseUp(object sender, MouseEventArgs e) {
			MouseEventArgs mouseE = new MouseEventArgs(e.Button, e.Clicks,
				e.X + picturebox.Left, e.Y + picturebox.Top, e.Delta);
			OnMouseUp(mouseE);
		}

		void label_MouseUp(object sender, MouseEventArgs e) {
			MouseEventArgs mouseE = new MouseEventArgs(e.Button, e.Clicks, e.X + label.Left, e.Y + label.Top, e.Delta);
			OnMouseUp(mouseE);
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
				ImageDelete();
			}			
		}

		void ImageDelete() {
			if(MessageBox.Show("確定刪除此節點？", "訊息提示",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				OnImageDeleting(new EventArgs());
				for(int i = ((List<ImageLink>)ParentControl.Tag).Count - 1; i >= 0; i--) {
					ImageLink imglink = ((List<ImageLink>)ParentControl.Tag)[i];
					if(imglink.StartImage == this || imglink.EndImage == this) {
						imglink.ClearOldLine();
						ParentControl.Controls.Remove(imglink);
						((List<ImageLink>)ParentControl.Tag).Remove(imglink);
					}
				}
				this.Controls.Clear();
				this.FindForm().ActiveControl = null;
				ParentControl.Controls.Remove(this);
				this.Dispose();
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

		protected override void OnMouseUp(MouseEventArgs e) {
			base.OnMouseUp(e);
		}

		protected override void OnMouseMove(MouseEventArgs e) {
			if(!CanMove) {
				base.OnMouseMove(e);
				return;
			}
			if(e.Button == MouseButtons.Left) {
				if(moveX > 0 && moveY > 0) {
					ImageBox.DrawLine = false;
					this.Left += e.X - moveX;
					this.Top += e.Y - moveY;
					if(((List<ImageLink>)ParentControl.Tag).Count > 0) ((List<ImageLink>)ParentControl.Tag)[0].ReDrawAll();
					base.OnMouseMove(e);
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
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Black),
						Width / 2 - offsetX, 0, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Black);
					base.OnMouseMove(e);
					return;
				}
				if(e.Y >= mdY && e.Y <= mdY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Black),
						Width / 2 - offsetX, Height - offsetY * 2, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Black);
					base.OnMouseMove(e);
					return;
				}				
			}

			int lX = 0;
			int rX = Width - offsetX * 2;
			int lrY = Height / 2 - offsetY;

			if(e.Y >= lrY && e.Y <= lrY + offsetY * 2) {
				if(e.X >= lX && e.X <= lX + offsetX * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Black),
						0, Height / 2 - offsetY, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Black);
					base.OnMouseMove(e);
					return;
				}
				if(e.X >= rX && e.X <= rX + offsetX * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Black),
						Width - offsetX * 2, Height / 2 - offsetY, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Black);
					base.OnMouseMove(e);
					return;
				}				
			}

			int ludX = 0;
			int luY = 0;
			int ldY = Height - offsetY * 2;

			if(e.X >= ludX && e.X <= ludX + offsetX * 2) {
				if(e.Y >= luY && e.Y <= luY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Black),
						0, 0, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Black);
					base.OnMouseMove(e);
					return;
				}
				if(e.Y >= ldY && e.Y <= ldY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Black),
						0, Height - offsetY * 2, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Black);
					base.OnMouseMove(e);
					return;
				}				
			}

			int rudX = Width - offsetX * 2;
			int ruY = 0;
			int rdY = Height - offsetY * 2;

			if(e.X >= rudX && e.X <= rudX + offsetX * 2) {
				if(e.Y >= ruY && e.Y <= ruY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Black),
						Width - offsetX * 2, 0, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Black);
					base.OnMouseMove(e);
					return;
				}
				if(e.Y >= rdY && e.Y <= rdY + offsetY * 2) {
					this.CreateGraphics().FillRectangle(new SolidBrush(Color.Black),
						Width - offsetX * 2, Height - offsetY * 2, offsetX * 2, offsetY * 2);
					if(ImageBox.DrawLine) DrawOldLine(Color.Black);
					base.OnMouseMove(e);
					return;
				}				
			}

			Draw(this.CreateGraphics());

			ImageBox.FormMouseMove(ParentControl, new MouseEventArgs(e.Button, e.Clicks, e.X + Left, e.Y + Top, e.Delta));
			base.OnMouseDown(e);
		}

		void label_MouseDown(object sender, MouseEventArgs e) {
			OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, e.X + label.Left, e.Y + label.Top, e.Delta));
		}

		void picturebox_MouseDown(object sender, MouseEventArgs e) {
			OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, e.X + picturebox.Left, e.Y + picturebox.Top, e.Delta));
		}		

		protected override void OnMouseDown(MouseEventArgs e) {
			if(this.FindForm().ActiveControl != this) {
				this.FindForm().ActiveControl = this;
			}

			moveX = 0;
			moveY = 0;

			arrow = Arrow.None;

			if(e.Button == MouseButtons.Left) {
				if(ImageBox.StartImage == this) {
					ImageBox.DrawLine = false;
					ImageBox.ClearOldLine(ParentControl);
					ImageBox.StartImage = null;
					ImageBox.oldMousePoint = Point.Empty;
				}
				if(!CanMove) {
					base.OnMouseDown(e);
					return;
				}

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
						if(this.data1.ToString() == "nEnd") return;
						ImageBox.DrawLine = true;
						ImageBox.StartImage = this;
						ImageBox.oldMousePoint = Point.Empty;
					}
					else {
						if(ImageBox.StartImage != this) {							
							ImageBox.DrawLine = false;
							ImageBox.ClearOldLine(ParentControl);

							if(this.data1.ToString() == "nStart") {
								MessageBox.Show("流程開始節點，不允許被連接", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}

							if(this.data1.ToString() == "nForm" && ImageBox.StartImage.data1.ToString() != "nStart") {
								MessageBox.Show("表單填寫節點，只能被流程開始節點連接", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}

							if(this.data1.ToString() == "nMultiInit" && ImageBox.StartImage.data1.ToString() != "nMultiStart") {
								MessageBox.Show("會簽起始者節點，只能被會簽流程節點連接", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}

							fmLineType dlgLinkType = new fmLineType();
							dlgLinkType.ShowDialog();
							Color myLineColor = ImageBox.lineColor;
							switch(dlgLinkType.linkType) {
								case LinkType.TrueCriteria:
									myLineColor = Color.Green;
									break;
								case LinkType.DefaultCriteria:
									myLineColor = Color.Red;
									break;
								case LinkType.NoCriteria:
									myLineColor = Color.Blue;
									break;
							}

							ImageLink imglink = new ImageLink(ImageBox.StartImage, this,
								ImageBox.lineWidth, myLineColor, dlgLinkType.linkStyle, dlgLinkType.linkText);
							imglink.LabelEdited += new ImageLink.LabelEditedEventHandler(imglink_LabelEdited);
							imglink.LinkContent += new ImageLink.LinkContentEventHandler(imglink_LinkContent);
							imglink.LinkDelete += new ImageLink.LinkDeleteEventHandler(imglink_LinkDelete);
							imglink.graphics = ParentControl.CreateGraphics();														
							ImageBox.StartImage = null;
							ImageBox.oldMousePoint = Point.Empty;
							((List<ImageLink>)ParentControl.Tag).Add(imglink);							
							ParentControl.Controls.Add(imglink);
							eventImageLink = imglink;
							OnLinkFinished(e);
						}
					}
				}
			}
			if (e.Button == MouseButtons.Right) {
				this.ContextMenuStrip = new ContextMenuStrip();
				if (this.data1.ToString() != "nMultiStart") {
					this.ContextMenuStrip.Items.Add("節點內容", null, new EventHandler(OnImageContent));
					this.ContextMenuStrip.Items.Add("-");
				}
				this.ContextMenuStrip.Items.Add("取消連接", null, new EventHandler(OnCancelLink));
				this.ContextMenuStrip.Items.Add("刪除節點", null, new EventHandler(OnImageDelete));
			}
		}

		void imglink_LinkDelete(object sender, EventArgs e) {
			OnLinkDelete(e);
		}

		void OnImageDelete(object sender, EventArgs e) {
			ImageDelete();
		}

		void OnImageContent(object sender, EventArgs e) {
			OnImageContent(e);
		}

		void imglink_LinkContent(object sender, EventArgs e) {
			eventImageLink = (ImageLink)sender;
			OnLinkContent(e);
		}

		void imglink_LabelEdited(object sender, EventArgs e) {
			eventImageLink = (ImageLink)sender;
			OnLinkLabelEdited(e);
		}

		void OnCancelLink(object sender, EventArgs e) {
			if(MessageBox.Show("您確定要取消連接嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				for(int i = ((List<ImageLink>)ParentControl.Tag).Count - 1; i >= 0; i--) {
					ImageLink imglink = ((List<ImageLink>)ParentControl.Tag)[i];
					if(imglink.EndImage == this) {
						imglink.ClearOldLine();
						ParentControl.Controls.Remove(imglink);
						((List<ImageLink>)ParentControl.Tag).Remove(imglink);
						eventImageLink = imglink;
						OnLinkCancel(e);
					}
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			Draw(e.Graphics);
		}

		public void Draw(Graphics g) {
			//上
			g.FillRectangle(new SolidBrush(ParentControl.BackColor),
				Width / 2 - offsetX, 0, offsetX * 2, offsetY * 2);
			//下
			g.FillRectangle(new SolidBrush(ParentControl.BackColor),
				Width / 2 - offsetX, Height - offsetY * 2, offsetX * 2, offsetY * 2);
			//左
			g.FillRectangle(new SolidBrush(ParentControl.BackColor),
				0, Height / 2 - offsetY, offsetX * 2, offsetY * 2);
			//右
			g.FillRectangle(new SolidBrush(ParentControl.BackColor),
				Width - offsetX * 2, Height / 2 - offsetY, offsetX * 2, offsetY * 2);
			//左上
			g.FillRectangle(new SolidBrush(ParentControl.BackColor),
				0, 0, offsetX * 2, offsetY * 2);
			//右上
			g.FillRectangle(new SolidBrush(ParentControl.BackColor),
				Width - offsetX * 2, 0, offsetX * 2, offsetY * 2);
			//左下
			g.FillRectangle(new SolidBrush(ParentControl.BackColor),
				0, Height - offsetY * 2, offsetX * 2, offsetY * 2);
			//右下
			g.FillRectangle(new SolidBrush(ParentControl.BackColor),
				Width - offsetX * 2, Height - offsetY * 2, offsetX * 2, offsetY * 2);

			if(this.FindForm() != null) {
				if(this.FindForm().ActiveControl == this) {
					g.DrawRectangle(new Pen(new SolidBrush(Color.Red), 2),
						offsetX, offsetY, Width - offsetX * 2 - 1, Height - offsetY * 2 - 1);
				}
				else {
					g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2),
						offsetX, offsetY, Width - offsetX * 2 - 1, Height - offsetY * 2 - 1);
				}
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
				this.CreateGraphics().DrawRectangle(new Pen(new SolidBrush(ParentControl.BackColor), 2),
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

		public static void FormMouseMove(object sender, MouseEventArgs e) {			
			ClearOldLine(sender);
			if(ImageBox.DrawLine) {
				((Control)sender).CreateGraphics().DrawLine(new Pen(new SolidBrush(lineColor),ImageBox.lineWidth), 
					ImageBox.StartImage.ArrowPoint,e.Location);
				ImageBox.oldMousePoint = e.Location;
				if(((List<ImageLink>)((Control)sender).Tag).Count > 0) 
					((List<ImageLink>)((Control)sender).Tag)[0].ReDrawAll();
			}

			for(int i = 0; i < ((Control)sender).Controls.Count; i++) {
				if(((Control)sender).Controls[i].GetType() == typeof(ImageBox)) {
					((ImageBox)((Control)sender).Controls[i]).Draw(((Control)sender).Controls[i].CreateGraphics());
				}
			}
		}

		public static void ClearOldLine(object sender) {
			if(ImageBox.oldMousePoint != Point.Empty) {
				((Control)sender).CreateGraphics().DrawLine(new Pen(new SolidBrush(((Control)sender).BackColor), ImageBox.lineWidth), 
					ImageBox.StartImage.ArrowPoint,ImageBox.oldMousePoint);
			}
		}

		public void DrawOldLine(Color color) {
			if(ImageBox.oldMousePoint != Point.Empty) {
				ParentControl.CreateGraphics().DrawLine(new Pen(new SolidBrush(color), ImageBox.lineWidth),
					ImageBox.StartImage.ArrowPoint, ImageBox.oldMousePoint);
			}
		}		
	}
}