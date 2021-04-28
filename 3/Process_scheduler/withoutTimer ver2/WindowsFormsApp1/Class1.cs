using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 *  작성자: 오차영
 *  내용  : Process클래스 구현과 Scheduler 추상클래스 선언
 *  
 *  private 자료형 변수명;
 *  public  자료형 변수명(비슷한상태)
 *  {
 *      get { return 변수명 ;}
 *      set { 변수명 = value;} 
 *  }
 *  
 *  이코드는 c#에서 지원하는 property라는 것으로
 *  getMethode, setMethode 와 기능적으로 같으나 
 *  실제 사용시 public변수처럼 getter와 setter가 아닌 
 *  직접 사용하는것이 가능하다
 **/
namespace WindowsFormsApp1
{
    class Process : IComparable<Process>
    {
        public readonly int processId;
        public readonly int arrivalTime;
        public readonly int burstTime;
        public readonly int priority;

        private int endtime;

        public int endTime
        {
            get { return endtime; }
            set { endtime = value; }
        }

        private int lastprocessor;

        public int lastProcessor
        {
            get { return lastprocessor; }
            set { lastprocessor = value; }
        }

        private int dybursttime;

        public int dyburstTime
        {
            get { return dybursttime; }
            set { dybursttime = value; }
        }

        private int dyArrivaltime;

        public int dyArrivalTime
        {
            get { return dyArrivaltime; }
            set { dyArrivaltime = value; }
        }

        private int rrtime;

        public int rrTime
        {
            get { return rrtime; }
            set { rrtime = value; }
        }

        
        public  Color Color { get; }
        //Color의 경우 한번 정하고 바꿀일이 없으므로 getter만 설정
        
        public void init()
        {
            endtime = 0;
            lastProcessor = 0;
            dyArrivalTime = 0;
            dyburstTime = 0;
            rrTime = 0;
        }

        private int waitingtime = -1;

        public int waitingTime
        {
            get { return waitingtime; }
            set { waitingtime = value; }
        }

        private int turnaroundtime = -1;

        public int turnaroundTime
        {
            get { return turnaroundtime; }
            set { turnaroundtime = value; }
        }

        private float nomalizedtime = -1;

        public float normalizedTime
        {
            get { return nomalizedtime; }
            set { nomalizedtime = value; }
        }



        public Process(int processId, int arrivalTime, int burstTime, Color color, int priority = 0)
        {
            this.processId = processId;
            this.arrivalTime = arrivalTime;
            this.burstTime = burstTime;
            this.Color = color;
            this.priority = priority;

        }

        public int CompareTo(Process obj)
        {
            return arrivalTime.CompareTo(obj.arrivalTime);
            //기본적인 CompareTo는 arrivalTime을 기주으로 한다.
        }


        /*
            프로세스에 값 넣는거는 알아서 사용 ㄱㄱ 근대 수정했으면 카톡방에 말할것

         */

    }
    abstract class Scheduler
    {
        //protected int[,] scheduledProcess = new int[4, 100];
        protected List<List<int>> scheduledProcess = new List<List<int>>();
        //프로세스의 최대 시간은 100초로 한정한다.

        private int endtime;

        public int endTime
        {
            get { return endtime; }
            set { endtime = value; }
        }



        public List<List<int>> getScheduledProcess()
        {
            return scheduledProcess;
        }
        public Scheduler()
        {
            scheduledProcess.Add(new List<int>());
            scheduledProcess.Add(new List<int>());
            scheduledProcess.Add(new List<int>());
            scheduledProcess.Add(new List<int>());
        }
        //public void init()
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        for (int j = 0; j < 100; j++)
        //        {
        //            scheduledProcess[i][j] = -1;//idle상태를 -1로 표현
        //        }
        //    }

        //}


        public abstract void scheduling(Process[] process, int processorNum, int rrNum);
        /*
            최종상태 scheduledProcess배열에 해당 시간에 현재 프로세스의 id값이 들어가는
            ex) 코어수 1개, p1 id = 1 arrivaltime = 0 bursttime= 3 p2 id = 2 arrivaltime = 2 bursttime= 2
            fcfs 방식이면 앞에서 부터 넣으니까
            1 1 1 2 2
            가 배열에 들어가 있으면 됨
            이 추상클래스를 상속받는 public class로 구현해서 그 파일만 넘겨주면됨
            */
    }



}
