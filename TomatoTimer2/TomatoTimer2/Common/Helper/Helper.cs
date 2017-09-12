using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TomatoTimer2
{
    public class WindowHelper
    {
        /// <summary>
        /// 지정된 타입의 윈도우를 리턴한다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> GetWindows<T>() where T : Window
        {
            var rslts = new List<T>();
            IEnumerator k = System.Windows.Application.Current.Windows.GetEnumerator();
            while (k.MoveNext())
            {
                if (k.Current is T)
                {
                    rslts.Add((T)k.Current);
                }
            }
            return rslts;
        } // end method

        /// <summary>
        /// 지정된 윈도우 객체를 리턴한다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetWindow<T>() where T : Window
        {
            IEnumerator k = System.Windows.Application.Current.Windows.GetEnumerator();
            while (k.MoveNext())
            {
                if (k.Current is T)
                {
                    return (T)k.Current;
                }
            }
            return null;
        }

        /// <summary>
        /// 윈도우를 생성한다.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static Window Create(Window parent, UserControl content)
        {
            var window = new Window();
            //window.Icon = ImageHelper.Convert(Properties.Resources.icon_hangul1);
            window.Owner = parent;
            window.ResizeMode = ResizeMode.NoResize;
            window.WindowStyle = WindowStyle.None;
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Content = content;
            return window;
        }
        public static Window Create(UserControl content)
        {
            var window = new Window();
            //window.Icon = ImageHelper.Convert(Properties.Resources.icon_hangul1);
            window.ResizeMode = ResizeMode.NoResize;
            window.WindowStyle = WindowStyle.None;
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Content = content;
            return window;
        }

        /// <summary>
        /// UI 즉시 반영
        /// </summary>
        /// <param name="element"></param>
        public static void ImmediatelyUpdateUI(FrameworkElement element)
        {
            element.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
            System.Threading.Thread.Sleep(100);
            element.Dispatcher.Invoke((ThreadStart)(() => { }), DispatcherPriority.ApplicationIdle);
        }

    } // end class
}
