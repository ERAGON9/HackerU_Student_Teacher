using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hackeru_Student_Teacher.ClientWPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ExamPage.xaml
    /// </summary>
    public partial class ExamPage : UserControl
    {
        public ExamPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// need to set the data base.
        /// </summary>
        /// <returns></returns>
        //public string GetQuestionFromDatabase()
        //{
        //    // Code to retrieve the question text from the database
        //    // Replace this with your actual database retrieval logic

        //    // For example, using SQLite
        //    using (var connection = new SQLiteConnection("YourConnectionString"))
        //    {
        //        connection.Open();
        //        var command = connection.CreateCommand();
        //        command.CommandText = "SELECT QuestionText FROM Questions WHERE QuestionId = 1"; // Assuming QuestionId = 1
        //        string questionText = command.ExecuteScalar()?.ToString();
        //        return questionText;
        //    }
        //}

        //string questionText = GetQuestionFromDatabase();


        //QuestionTextBlock.Text = questionText;

    }
}
