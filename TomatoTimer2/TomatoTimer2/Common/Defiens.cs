using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer2
{
    public class Defines
    {
        ///// <summary>
        ///// Auth
        ///// </summary>
        //public const string AUTH_STR = "b_c7a06f684fccac7c853874d22cf81026";

        /// <summary>
        /// 통신서버 정보, LoginView.xaml.cs로 옮김 by대경. 
        /// </summary>

        /// <summary>
        /// 업로드 완료 폴더
        /// </summary>
        //public const string UPLOAD_COMPLETED_FOLDERNAME = ".UploadCompleted";

        /// <summary>
        /// Local Repository path
        /// </summary>
        public static readonly string LOCALREPOSITORY_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\TomatoTimer2";

        /// <summary>
        /// Local Repository Filename
        /// </summary>
        public const string LOCALREPOSITORY_FILENAME = "TomatoTimer2_repository.data";

        /// <summary>
        /// Open Folder path
        /// </summary>
        //public static readonly string Folder_PATH = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        /// <summary>
        /// 업로드 타스크 최대 수
        /// </summary>
        //public const int UPLOAD_TASK_MAX_COUNT = 3;

        /// <summary>
        /// 레지스트리 키
        /// </summary>
        //public const string REG_PATH = @"Software\PanoptoContainer";
        //public const string REG_KEY1 = "UserKey";
        //public const string REG_KEY2 = "Password";
        //public const string REG_KEY3 = "Host";

        /// <summary>
        /// 프로그레스 로그 최대 누적 갯수
        /// </summary>
        //public const int PROGRESS_LOG_MAX_COUNT = 100;

        /// <summary>
        /// 업로드 로그 최대 누적 갯수
        /// </summary>
        //public const int UPLOAD_LOG_MAX_COUNT = 200;
    }
}
