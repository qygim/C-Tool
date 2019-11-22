using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

public class Sticker : Control
{
	Bitmap BitMap;
	PictureBox PictureImage;
	string Path;
	bool IsClick;

	public PictureBox Picture
	{
		get { return PictureImage; }
	}

	public bool Click
	{
		get { return IsClick; }
		set { IsClick = value; }
	}

	public string P
	{
		get { return Path; }
	}

	public Sticker(string P)
	{
		Path = P;
		PictureImage = new PictureBox();
		Picture.Left = 650;
		Picture.Top = 40;
		Picture.Width = 10;
		Picture.Height = 10;
		Picture.SizeMode = PictureBoxSizeMode.AutoSize;

		BitMap = new Bitmap(Path);
		Picture.Image = (Image)BitMap;
		Picture.BackColor = Color.Transparent;
	}

	public Sticker(Bitmap B)
	{
		PictureImage = new PictureBox();
		Picture.Left = 650;
		Picture.Top = 40;
		Picture.Width = 10;
		Picture.Height = 10;
		Picture.SizeMode = PictureBoxSizeMode.AutoSize;

		Picture.Image = (Image)B;
		Picture.BackColor = Color.Transparent;
	}

	public bool IsSeleted(Point P)
	{
		if (P.X>=Picture.Left && P.X<=Picture.Left+Picture.Width)
		{
			if(P.Y>=Picture.Top && P.Y<=Picture.Top+Picture.Height)
			{
				return true;
			}
		}

		return false;
	}
}

