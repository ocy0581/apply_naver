using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace withoutTimer
{
    class TeamScheduler : Scheduler
    {
        private int[] currProcessList;
        private List<Process> heap;
        private int[] processor;
        private Process currProcess;
        private int tmpCount = 0;
        private int time = 0;

        public TeamScheduler()
        {

            heap = new List<Process>();
            processor = new int[4];
            currProcessList = new int[4];

        }
        public override void scheduling(Process[] process, int processorNum, int rrNum)
        {
            Array.Sort(process);
            for (int i = 0; i < 4; i++)
            {
                scheduledProcess[i].Add(-1);
                currProcessList[i] = -1;
            }
            addHeap(process);
            while ((tmpCount < process.Count() || heap.Any())
                || currProcessList[0] + currProcessList[1] +
                currProcessList[2] + currProcessList[3] !=-4)//2개가 같다 == 맨 마지막을 넘겼다.(인덱스 오류가 났다.)
            {
                for (int i = 0; i < processorNum; i++)//프로세서중에
                {
                    if (processor[i] <= 0)//일이 없는 프로세서가 있다면
                    {
                        currProcessList[i] = -1;
                        if (!heap.Any())
                        {
                            --processor[i];
                            scheduledProcess[i][time] = currProcessList[i];
                            continue;
                        }
                        currProcess = heap[heap.Count() - 1];//heap에서 값을 꺼내고 값을 지운다.
                        heap.RemoveAt(heap.Count() - 1);

                        currProcessList[i] = currProcess.processId;

                        processor[i] = currProcess.burstTime;

                        currProcess.waitingTime = time - currProcess.arrivalTime;
                        currProcess.turnaroundTime = currProcess.waitingTime + currProcess.burstTime;
                        currProcess.normalizedTime = (float)currProcess.turnaroundTime / currProcess.burstTime;
                    }
                    scheduledProcess[i][time] = currProcessList[i];
                    --processor[i];
                }
                time++;
                addHeap(process);
                for (int i = 0; i < 4; i++)
                {
                    scheduledProcess[i].Add(-1);
                }

            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    scheduledProcess[i].Add(-1);
                }
            }
            endTime = scheduledProcess[0].Count();
        }
        private int addHeap(Process[] processes)
        {

            var item = from process in processes
                       where process.arrivalTime == time
                       select process;
            heap.AddRange(item);
            tmpCount += item.Count();

            var com = new compare(time);
            heap.Sort(com);//compareTo는 이미 process에서 수정되있으므로 다시 comparer를 만든다.
            return item.Count();
        }
        public class compare : IComparer<Process>
        {
            int time = 0;
            public compare(int time)
            {
                this.time = time;
            }
            public int Compare(Process x, Process y)
            {
                float tmp1 = (float)((time - x.arrivalTime) + x.burstTime + x.priority) / x.burstTime;
                float tmp2 = (float)((time - y.arrivalTime) + y.burstTime + y.priority) / y.burstTime;

                return tmp1.CompareTo(tmp2);

            }
        }
    }
}
    