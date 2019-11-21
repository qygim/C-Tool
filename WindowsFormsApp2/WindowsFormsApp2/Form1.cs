using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Resources;

namespace WindowsFormsApp2
{
	public partial class Form1 : Form
	{
		private Point CurrentPicturePos;
		private Point CurrentMousePos;
		private int Index;

		private string Path =  @"..\..\Resource2\Background2.jpg";
		private string Path2 = @"..\..\Resource2\buttonSelect3.png";
		private string Path3 = @"..\..\Resource2\checkmark2.png";
		private string Path4 = @"..\..\Resource2\return2.png";
		private string Path5 = @"..\..\Resource2\Progress.png";

		List<Sticker> StickerList = new List<Sticker>();

		public Form1()
		{
			InitializeComponent();
		}

		private void ImageSet()
		{
			pictureBox2.Load(Path);
			pictureBox4.Load(Path);
			pictureBox5.Load(Path);
			pictureBox6.Load(Path2);
			pictureBox7.Load(Path2);
			pictureBox8.Load(Path3);
			pictureBox9.Load(Path3);
			pictureBox10.Load(Path3);
			pictureBox11.Load(Path3);
			pictureBox12.Load(Path5);
			pictureBox13.Load(Path5);
			pictureBox14.Load(Path5);
			pictureBox15.Load(Path5);
			pictureBox17.Load(Path5);
			pictureBox18.Load(Path3);

			pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox6.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBox7.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox12.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBox13.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBox14.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBox15.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBox17.SizeMode = PictureBoxSizeMode.AutoSize;
			pictureBox18.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		private void InitSet()
		{
			NickNameWrite.Visible = false;
			GuildWrite.Visible = false;
			JobWrite.Visible = false;
			ServerWrite.Visible = false;
			EtcWrite.Visible = false;
		}

		private void ComboBoxSet()
		{
			string[] StickerName =
			{
				"꾸미기 스티커",
				"반가움",
				"엑스",
				"느낌표1",
				"느낌표2",
				"화난 얼굴",
				"웃는 얼굴",
				"슬픈 얼굴",
				"하트",
				"깨진 하트",
				"물음표",
				"쿨쿨",
				"별"
			};

			Decorate.Items.AddRange(StickerName);
			Decorate.SelectedIndex = 0;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ImageSet();
			InitSet();
			ComboBoxSet();
		}
		
		private void StickerMouseDown(object sender,MouseEventArgs M)
		{
			if(M.Button==MouseButtons.Left)
			{
				Point Check = this.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
				for(int i=0;i<StickerList.Count;i++)
				{
					if(StickerList[i].IsSeleted(Check))
					{
						Index = i;
						break;
					}
				}
				this.CurrentPicturePos = StickerList[Index].Picture.Location;
				this.CurrentMousePos = new Point(M.X, M.Y);
			}
		}

		private void StickerMove(object sender,MouseEventArgs M)
		{
			if(M.Button==MouseButtons.Left)
			{
				StickerList[Index].Picture.Left = StickerList[Index].Picture.Left + (M.X - this.CurrentMousePos.X);
				StickerList[Index].Picture.Top = StickerList[Index].Picture.Top + (M.Y - this.CurrentMousePos.Y);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
		
		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
		}

		private void Save_MouseDonw(object sender, MouseEventArgs e)
		{
			VisibleFalse();
		}

		private void Save_Click(object sender, EventArgs e)
		{
			Size ScreenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			Graphics MyG = this.CreateGraphics();
			Bitmap BitMap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height, MyG);


			Point Picture = PointToScreen(new Point(this.ClientRectangle.Left, this.ClientRectangle.Top));
			Graphics G = Graphics.FromImage(BitMap);
			G.CopyFromScreen(0, 0, -Picture.X - 6, -Picture.Y - 10, ScreenSize);
			BitMap.SetResolution(300, 300);

			string FileName;
			SaveFileDialog SaveFile = new SaveFileDialog();
			SaveFile.Title = "저장경로를 지정하세요";
			SaveFile.OverwritePrompt = true;
			SaveFile.Filter = "JPEG File(*.jpg)|*.jpg|PNG File(*png)|*.png";

			if (SaveFile.ShowDialog() == DialogResult.OK)
			{
				FileName = SaveFile.FileName;
				//BitMap.Save(Application.StartupPath + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png", ImageFormat.Png);
				BitMap.Save(FileName);
			}

			else
			{
				VisibleTrue();
			}
		}

		private void VisibleFalse()
		{
			pictureBox8.Visible = false;
			pictureBox9.Visible = false;
			pictureBox10.Visible = false;
			pictureBox11.Visible = false;
			pictureBox18.Visible = false;
		}

		private void VisibleTrue()
		{
			pictureBox8.Visible = true;
			pictureBox9.Visible = true;
			pictureBox10.Visible = true;
			pictureBox11.Visible = true;
			pictureBox18.Visible = true;
		}

		private void pictureBox6_Click(object sender, EventArgs e)
		{
			OpenFileDialog Open = new OpenFileDialog();
			Open.InitialDirectory = "C:\\";
			if (Open.ShowDialog() == DialogResult.OK)
			{
				string Path = Open.FileName;
				if (Path != "")
				{
					System.Drawing.Bitmap BitMap = new Bitmap(Path);
					pictureBox1.Image = BitMap;
					pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				}
			}
		}

		private void pictureBox7_Click(object sender, EventArgs e)
		{
			OpenFileDialog Open = new OpenFileDialog();
			Open.InitialDirectory = "C:\\";

			if (Open.ShowDialog() == DialogResult.OK)
			{
				string Path = Open.FileName;
				if (Path != "")
				{
					System.Drawing.Bitmap BitMap = new Bitmap(Path);
					pictureBox3.Image = BitMap;
					pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
				}
			}
		}

		private void pictureBox8_Click(object sender, EventArgs e)
		{
			if (!NickNameWrite.Visible)
			{
				NickNameWrite.Text = NickNameText.Text;
				NickNameText.Visible = false;
				NickNameWrite.Visible = true;
				pictureBox8.Load(Path4);
				pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
			}

			else
			{
				NickNameText.Visible = true;
				NickNameWrite.Visible = false;
				pictureBox8.Load(Path3);
				pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}

		private void pictureBox9_Click(object sender, EventArgs e)
		{
			if (!GuildWrite.Visible)
			{
				GuildWrite.Text = GuildText.Text;
				GuildText.Visible = false;
				GuildWrite.Visible = true;
				pictureBox9.Load(Path4);
				pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
			}

			else
			{
				GuildText.Visible = true;
				GuildWrite.Visible = false;
				pictureBox9.Load(Path3);
				pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}

		private void pictureBox10_Click(object sender, EventArgs e)
		{
			if (!JobWrite.Visible)
			{
				JobWrite.Text = JobText.Text;
				JobText.Visible = false;
				JobWrite.Visible = true;
				pictureBox10.Load(Path4);
				pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
			}

			else
			{
				JobText.Visible = true;
				JobWrite.Visible = false;
				pictureBox10.Load(Path3);
				pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}

		private void pictureBox11_Click(object sender, EventArgs e)
		{
			if (!ServerWrite.Visible)
			{ 
				ServerWrite.Text = ServerText.Text;
				ServerText.Visible = false;
				ServerWrite.Visible = true;
				pictureBox11.Load(Path4);
				pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
			}

			else
			{
				ServerText.Visible = true;
				ServerWrite.Visible = false;
				pictureBox11.Load(Path3);
				pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}
		
		private void pictureBox18_Click(object sender, EventArgs e)
		{
			if (!EtcWrite.Visible)
			{
				EtcWrite.Text = EtcText.Text;
				EtcText.Visible = false;
				EtcWrite.Visible = true;
				pictureBox18.Load(Path4);
				pictureBox18.SizeMode = PictureBoxSizeMode.StretchImage;
			}

			else
			{
				EtcText.Visible = true;
				EtcWrite.Visible = false;
				pictureBox18.Load(Path3);
				pictureBox18.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}
		
		private void Decorate_SelectedIndexChanged(object sender, EventArgs e)
		{
			//ResourceManager RM = WindowsFormsApp2.Properties.Resources.ResourceManager;
			//StickerList.Add((Bitmap)RM.GetObject("emote_alert.png"));

			if (Decorate.SelectedIndex != 0)
			{
				string Path = ImagePath(Decorate.SelectedIndex);
				Sticker New = new Sticker(Path);
				New.Picture.MouseDown += StickerMouseDown;
				New.Picture.MouseMove += StickerMove;
				this.Controls.Add(New.Picture);
				New.Picture.BringToFront();
				StickerList.Add(New);
			}
		}

		private string ImagePath(int SeletedIndex)
		{
			string Path = string.Empty;

			switch(SeletedIndex)
			{
				case 1:
					Path = @"..\..\Resource\emote_alert.png";
					//Path = @"WindowsFormsApp2.Properties.Resources.emote_alert";
					break;

				case 2:
					Path = @"..\..\Resource\emote_cross.png";
					break;

				case 3:
					Path = @"..\..\Resource\emote_exclamation.png";
					break;

				case 4:
					Path = @"..\..\Resource\emote_exclamations.png";
					break;

				case 5:
					Path = @"..\..\Resource\emote_faceAngry.png";
					break;

				case 6:
					Path = @"..\..\Resource\emote_faceHappy.png";
					break;

				case 7:
					Path = @"..\..\Resource\emote_faceSad.png";
					break;

				case 8:
					Path = @"..\..\Resource\emote_heart.png";
					break;

				case 9:
					Path = @"..\..\Resource\emote_heartBroken.png";
					break;

				case 10:
					Path = @"..\..\Resource\emote_question.png";
					break;

				case 11:
					Path = @"..\..\Resource\emote_sleeps.png";
					break;

				case 12:
					Path = @"..\..\Resource\emote_star.png";
					break;

				
			}

			return Path;
		}
	}
}
