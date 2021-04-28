using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using withoutTimer;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        //utility 다른 함수들

        private Color complementoryColor(Color color)
        {
            //보색 구하는 함수
            //보색 = 255 - 원래색의 r,g,b
            List<byte> rgb = new List<byte>() { color.R, color.G, color.B };
            rgb.Sort();
            int sum = 255;
            //if (rgb[0] + rgb[2] <= 255)
            //    sum = rgb[0] + rgb[2];
            int tmpr = sum - color.R;
            int tmpg = sum - color.G;
            int tmpb = sum - color.B;

            Color newcolor = Color.FromArgb(255 - color.A, tmpr, tmpg, tmpb);
            return newcolor;

        }



        private void printProcessList()
        {
            /*
             * 왼쪽 리스트뷰(프로세스가 있는곳)을 출력하는함수
             * */
            processList.BeginUpdate();//바꾸기전에 업데이트하는것을 알려 변경되는것을 막는다.

            processList.Items.Clear();//내용물을 다 지운다.

            foreach (var process in processes)
            {
                ListViewItem lvi = new ListViewItem()//listView객체 안에 1개의 레코드를 설정하는것
                {//맨 첫칸 processId있는칸이므로 p와 숫자 그리고 각각의 색깔을 입력한다.
                    Text = "P" + process.processId.ToString(),
                    BackColor = process.Color,
                    ForeColor = complementoryColor(process.Color),
                    UseItemStyleForSubItems = false
                };

                //추가적인 정보들 (arrivalTime,burstTime,priority순으로 입력한다.
                
                //lvi.SubItems.Add(process.processId.ToString(), Color.Black, process.Color, Font);
                lvi.SubItems.Add(process.arrivalTime.ToString());
                lvi.SubItems.Add(process.burstTime.ToString());
                lvi.SubItems.Add(process.priority.ToString());
                //만약 정보들이 수정되있다면 (초기값 -1)
                if (process.waitingTime != -1)
                    lvi.SubItems.Add(process.waitingTime.ToString());
                if (process.turnaroundTime != -1)
                    lvi.SubItems.Add(process.turnaroundTime.ToString());
                if (process.normalizedTime != -1)
                    lvi.SubItems.Add(process.normalizedTime.ToString());

                //모든 정보가 들어갔다면 이 값을 list에 반영한다.
                processList.Items.Add(lvi);
            }

            processList.EndUpdate();
            //업데이트가 끝났으니 다시 화면에 출력한다.
        }
        private void printScheduledProcess()
        {
            int i = 0, j = 0;
            try
            {

                schedulerList.BeginUpdate();//계산전 출력 정지
                schedulerList.Items.Clear();//내용 비우기
                var scheduledProcess = scheduler.getScheduledProcess();//scheduling이 끝난 결과를 받아온다.
               
                for (i = 0; i < scheduler.endTime; i++)
                {
                    ListViewItem lvi = new ListViewItem()
                    {
                        Text = "" +     i,//맨 첫칸은 시간 0초부터 endTime+4초(start_Click에서 처리됨)까지 출력한다
                        UseItemStyleForSubItems = false
                    };
                    for (j = 0; j < 4; j++)
                    {
                        if (scheduledProcess[j][i] != -1)//-1이 아니다 == process가 들어있다.
                        {
                            var currProcess = processes[scheduledProcess[j][i] - 1];//process를 뽑고 processid가 순서대로 있고 
                            Color color = complementoryColor(currProcess.Color);    //processId는 1부터 시작해서 -1을 하여 index로 접근한다.

                            lvi.SubItems.Add("P" + currProcess.processId.ToString(), color, currProcess.Color, Font);
                            //해당칸에 P숫자(processId) 색깔 글자색(보색) 폰트를 적용하여 들어갈 객체(레코드)를 만든다.
                        }
                        else
                        {
                            lvi.SubItems.Add("IDLE", Color.White, Color.Black, Font);
                            //만약 process가 없는 경우 idle상태이므로 idle을 삽입하고 검은 배경에 흰 글씨로 삽입한다.
                        }   
                    }
                    schedulerList.Items.Add(lvi);
                }

            }
            catch (NullReferenceException except)
            {
                //scheduler가 정해지지 않은 상태로 reset이 눌린경우 
                //scheduler에서 개체참조오류(NullReferenceException)이 발생하므로 
                //처리를 안한다. start버튼에서 발생할 오류는 처리하므로 
                //이곳이 지나가는 경우는 맨 윗경우 1가지이다.
            }
            catch (Exception except)
            {
                MessageBox.Show("Form1.printScheduledProces\n" + except.Message + " i:" + i + " j" + j+"\n"+except.GetType());
            }
            finally
            {
                schedulerList.EndUpdate();//에러가 나도 업데이트는 해야하므로 끝을 알린다.
            }

        }


    }
}
