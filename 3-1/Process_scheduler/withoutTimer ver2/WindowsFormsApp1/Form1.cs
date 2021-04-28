using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using withoutTimer;
/*
* 작성자 : 오차영
* 내용   : window Form을 이용하여 다양한 디자인의 이벤트 처리 구현
* */
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Image, pictureBox1.Size);
            //사진의 이미지를 다시 설정한다.(픽셀 맞춰도 오류가 발생함)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            printProcessList();
            //맨 처음 불러졌을때(프로글매 시작)
            //MessageBox.Show(Application.StartupPath);


            Type colorType = typeof(System.Drawing.Color);


            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);

            foreach (PropertyInfo c in propInfoList)
            {
                var t = Color.FromName(c.Name);
                if (t.R + t.G + t.B > 250)
                {
                    this.colors.Items.Add(c.Name);
                        
                }
                //color 콤보 박스에 색깔을 추가한다 단 rgb합 250이 넘는 경우만 추가한다.
                //어두운 색의 경우 보색이 흐릿함)
            }
            colors.Text = "Red";
            //최초 색상은 red
        }




        private void input_Click(object sender, EventArgs e)
        {

            this.inputArrivalTime.Focus();
            try
            {

                processes.Add(new Process(int.Parse(processNum.Text), int.Parse(inputArrivalTime.Text),
                                int.Parse(inputBurstTime.Text), currentColor,int.Parse(priority.Text)));
                //입력된 값을 이용해서 process를 만든다
                processNum.Text = (int.Parse(processNum.Text) + 1).ToString();
            }
            catch
            {
                MessageBox.Show("모든 칸에 숫자를 입력해 주세요");
                //priority의 경우 0이 기본값이라 그값을 제외하고 안에 값이 없으면 발생한다.

            }
            printProcessList();
            Random random = new Random();
            colors.SelectedIndex = random.Next(colors.Items.Count);
            //다음 색상은 일단 랜덤으로 들어가지만 다시 설정 가능하다.
        }

        private void reset_Click(object sender, EventArgs e)
        {
            this.inputArrivalTime.Focus();//arrivaltime칸으로 커서(키보드입력)가 이동
            processes.Clear();//process 비우기
            processNum.Text = "1";//id초기화
            rrNum.Text = "0";//
            try
            {
                scheduler = (Scheduler)Activator.CreateInstance(scheduler.GetType());
                //scheduler의 타입을 보고 동적으로 다시 같은 클래스의 인스턴스를 생성하여 리턴해주는 코드
                //객체안에 있는 static을 제외한 모든 변수를 초기화 시키기위해 사용
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //여기서도 발생하는 오류 scheduler에 객체가 할당안되있는경우 
                //
            }
            finally
            {
                printProcessList();
                printScheduledProcess();
            }
        }

        private void schedulerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            rrNum.ReadOnly = true;//rrNum에 숫자입력을 할수 없다
            priority.ReadOnly = true;//priority에 숫자입력을 할수 없다
            priority.Text = "0";
            if (schedulers.SelectedItem.Equals("FCFS"))
            {
                scheduler = new FCFS();

            }
            else if (schedulers.SelectedItem.Equals("RR"))
            {

                rrNum.ReadOnly = false;
                scheduler = new RR();

            }
            else if (schedulers.SelectedItem.Equals("SPN"))
            {
                scheduler = new SPN();
            }
            else if (schedulers.SelectedItem.Equals("SRTN"))
            {
                scheduler = new SRTN();
            }
            else if (schedulers.SelectedItem.Equals("HRRN"))
            {
                scheduler = new HRRN();

            }
            else if (schedulers.SelectedItem.Equals("TeamScheduler"))
            {
                priority.ReadOnly = false;
                scheduler = new TeamScheduler();
            }
            else
            {
                MessageBox.Show("방식을 다시 선택해 주세요.");
            }
            //comboBox에 있는 값이 들어오면 그 값에 해당하는 scheduler를 할당함


        }

        private void start_Click(object sender, EventArgs e)
        {
            if (processes.Count == 0)
            {
                MessageBox.Show("process가 없습니다.");
                return;
            }

            try
            {
                Process[] arrProcess = processes.ToArray();


                if (rrNum.Text.Equals("")) rrNum.Text = "0";
                
                if (int.Parse(processorNum.Text) > 4 || int.Parse(processorNum.Text) < 1)
                    throw new Exception("processor의 수가 올바르지 않습니다.");
                scheduler = (Scheduler)Activator.CreateInstance(scheduler.GetType());
                //scheduler를 실행하기전에 자신의 클래스에서 인스턴스를 생성하여 자신에게 할당하여
                //객체의 초기화를 강제로 시킴(여러명이 만드는 코드이기에 각 class안에있는 멤버들이 
                //어떤값인지 알수 없고 초기화가 잘 되고있는지 확인할수 없으므로 강제로 초기화하여 실행함
                scheduler.scheduling(arrProcess, int.Parse(processorNum.Text), int.Parse(rrNum.Text));

                
            }
            catch(NullReferenceException nullex)
            {
                //개체참조오류 scheduler를 설정아하고 사용시 발생
                MessageBox.Show("Form1.start_Click->NullReferenceException\n" + nullex.Message + "\nscheduler가 선택되지 않았습니다.");
            }
            catch (Exception except)
            {
                MessageBox.Show("Form1.start_Click -> Exception\n" + except.Message + "\n현재 scheduler : " + scheduler.GetType());
            }


            printProcessList();
            printScheduledProcess();



        }




        private void colors_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {

                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X + 63, rect.Top);
                g.FillRectangle(b, rect.X + 3, rect.Y + 1,
                                rect.X + 50, rect.Height - 1);
            }
            //color combobox안에 글자외에 색을 표현하는 상자까지 그려서 색상을 눈으로 보고 선택 가능하게함
        }

        private void colors_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentColor = Color.FromName(colors.Text);
        }


        //private void stopButton_Click(object sender, EventArgs e)
        //{
        //    stop = true;
        //}
    }
}
