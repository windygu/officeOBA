using System.Threading;

namespace Cooperativeness.FileTransfer.Downloader
{

    public enum ActionStateType
    {
        Stop = 0x0,
        Running = 0x1,
        Pause = 0x2,
    }

    /// <summary> 
    /// �ֿ���Ϣ��,����˵����ÿ���ļ������ʼ��ַ
    //  ÿ��ĳ���,�Լ��Ŀ��Ѿ������˶������ݵ�
    //  ��Ϣ
    /// </summary> 

    public class BlockState
    {
        public BlockState()
        //            : this(0, 0, 0, ActionStateType.STOP, null)
        {
            Start = 0;
            Size = 0;
            TransmittedSize = 0;
            BlockRunState = ActionStateType.Stop;
            AssistThread = null;
        }

        public BlockState(int start, int size, int ts)
//            : this(start, size, ts, ActionStateType.STOP, null)
        {
            Start = start;
            Size = size;
            TransmittedSize = ts;
            BlockRunState = ActionStateType.Stop;
            AssistThread = null;
        }
/*
		public BlockState(int start, int size, int ts, ActionStateType ast, Thread thread)
		{
			Start	= start;
			Size	= size;
			TransmittedSize = ts;
			BlockRunState = ast;
			_thread = thread;
		}
*/
        /// <summary>
        /// ÿ�鿪ʼ�ĵ�ַ,���ֽڳ��ȱ�ʾ
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// ÿ��ĳ���,���ֽڳ�������ʾ
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// ��ǰ���Ѿ�������ɵ��ֽ���
        /// </summary>
        public int TransmittedSize { get; set; }

		public int UnTransmittedSize
		{
			get { return Size - TransmittedSize; }
		}

		public int EnterPoint
		{
			get { return Start + TransmittedSize; }
		}

        /// <summary>
        /// ����ʱ��״̬
        /// </summary>
        public ActionStateType BlockRunState { get; set; }

        /// <summary>
        /// �������߳�
        /// </summary>
        public Thread AssistThread { get; set; }

		public virtual bool IsCompleted
		{
			get { return (TransmittedSize >= Size && Size > 0); }
		}
	}
}
