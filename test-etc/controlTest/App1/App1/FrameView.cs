using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class FrameView : ContentView
    {
        public DateTime CurrentDate { get; private set; }

        public int CurrentMonth { get; private set; }

        public int CurrentYear { get; private set; }

        public int CurrentNoOfDaysInAMonth { get; private set; }

        public DayOfWeek CurrentDayOfTheWeek { get; private set; }

        public int CurrentDay { get; private set; }

        public Grid CalenderViewControl
        {
            get;
            set;
        }


        public GestureFrame gi
        {
            get;
            set;
        }

        public FrameView()
        {
            gi = new GestureFrame
            {
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                //VerticalOptions = LayoutOptions.Start,
                BackgroundColor = Color.FromHex("#33A7D6"),
                Padding = 1,
            };

            gi.SwipeLeft += Gi_SwipeLeft;
            gi.SwipeRight += Gi_SwipeRight;

            CurrentDate = DateTime.Now.Date;
            CurrentMonth = DateTime.Now.Month;
            CurrentYear = DateTime.Now.Year;
            CurrentDay = DateTime.Now.Day;
            CurrentDayOfTheWeek = new DateTime(CurrentYear, CurrentMonth, 1).DayOfWeek;
            CurrentNoOfDaysInAMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);


            LoadCalender();
        }

        public void LoadCalender()
        {
            CalenderViewControl = new Grid()
            {
                BackgroundColor = Color.Gray,//.Red,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //VerticalOptions = LayoutOptions.Start 
            };
            var monthLabel = new Label() { Text = CurrentMonth.ToString(), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
            CalenderViewControl.Children.Add(monthLabel, 0, 0);
            var yearLabel = new Label() { Text = CurrentYear.ToString(), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
            CalenderViewControl.Children.Add(yearLabel, 1, 0);

            //CalenderViewControl.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            //CalenderViewControl.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            //CalenderViewControl.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            //CalenderViewControl.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            //CalenderViewControl.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            //CalenderViewControl.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
            //CalenderViewControl.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });

            var weekDay = new Label() { Text = "Sun", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
            CalenderViewControl.Children.Add(weekDay, 0, 1);
            weekDay = new Label() { Text = "Mon", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
            CalenderViewControl.Children.Add(weekDay, 1, 1);
            weekDay = new Label() { Text = "Tue", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
            CalenderViewControl.Children.Add(weekDay, 2, 1);
            weekDay = new Label() { Text = "Wed", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
            CalenderViewControl.Children.Add(weekDay, 3, 1);
            weekDay = new Label() { Text = "Thu", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
            CalenderViewControl.Children.Add(weekDay, 4, 1);
            weekDay = new Label() { Text = "Fri", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
            CalenderViewControl.Children.Add(weekDay, 5, 1);
            weekDay = new Label() { Text = "Sat", HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, };
            CalenderViewControl.Children.Add(weekDay, 6, 1);

            //MonthAndYear.Children.Add(CalenderViewControl, 0, 2);
            //Grid.SetColumnSpan(CalenderViewControl, 2);

            CurrentDay = (CurrentMonth == DateTime.Now.Month && CurrentYear == DateTime.Now.Year) ? DateTime.Now.Day : 0;
            var startDaytoPrintInCalender = -1;
            switch (CurrentDayOfTheWeek)
            {
                case DayOfWeek.Sunday:
                    startDaytoPrintInCalender = 0;
                    break;

                case DayOfWeek.Monday:
                    startDaytoPrintInCalender = 1;
                    break;

                case DayOfWeek.Tuesday:
                    startDaytoPrintInCalender = 2;
                    break;

                case DayOfWeek.Wednesday:
                    startDaytoPrintInCalender = 3;
                    break;

                case DayOfWeek.Thursday:
                    startDaytoPrintInCalender = 4;
                    break;

                case DayOfWeek.Friday:
                    startDaytoPrintInCalender = 5;
                    break;

                case DayOfWeek.Saturday:
                    startDaytoPrintInCalender = 6;
                    break;

                default:
                    startDaytoPrintInCalender = -1;
                    break;
            }

            Label dateLabel = null;
            Frame frame = null;
            bool startDaySelected = false;
            int day = 1;
            for (int i = 2; i < 8; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (!startDaySelected)
                    {
                        if (j >= startDaytoPrintInCalender)
                        {
                            startDaySelected = true;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (startDaySelected)
                    {
                        if (day > CurrentNoOfDaysInAMonth)
                        {
                            break;
                        }

                        frame = new Frame() { HasShadow = false, Padding = 0, BackgroundColor = CurrentDay == day ? Color.Gray : Color.Transparent, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
                        dateLabel = new Label() { Text = (day).ToString(), FontSize = 18, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
                        frame.Content = dateLabel;
                        CalenderViewControl.Children.Add(frame, j, i);
                        day++;
                    }
                }
            }
            gi.Content = CalenderViewControl;
            this.Content = gi;
        }

        void Gi_SwipeLeft(object sender, EventArgs e)
        {
            CurrentDate = DateTime.Now.Date;
            CurrentMonth++;
            if (CurrentMonth > 12)
            {
                CurrentMonth = 1;
                CurrentYear++;
            }

            CurrentDayOfTheWeek = new DateTime(CurrentYear, CurrentMonth, 1).DayOfWeek;
            CurrentNoOfDaysInAMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);

            LoadCalender();
        }

        void Gi_SwipeRight(object sender, EventArgs e)
        {
            CurrentDate = DateTime.Now.Date;
            CurrentMonth--;
            if (CurrentMonth < 1)
            {
                CurrentMonth = 12;
                CurrentYear--;
            }

            CurrentDay = DateTime.Now.Day;
            CurrentDayOfTheWeek = new DateTime(CurrentYear, CurrentMonth, 1).DayOfWeek;
            CurrentNoOfDaysInAMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);

            LoadCalender();
        }


    }
}
