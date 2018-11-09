using Newtonsoft.Json;
using nudata.DomainClasses.Main;
using nudata.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nudata.nubackRepos
{
    public class TeacherCardItemRepo
    {
        public string ApiEndpoint;

        public TeacherCardItemRepo(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
        }

        public List<TeacherCardItem> all()
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCardItem/all");

            List<TeacherCardItem> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<TeacherCardItem>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string add(TeacherCardItem TeacherCardItem)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/teacherCardItem/add",
                new Dictionary<string, string>
                {
                    { "semester", TeacherCardItem.semester.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "code", TeacherCardItem.code },
                    { "discipline_name", TeacherCardItem.discipline_name },
                    { "group_name", TeacherCardItem.group_name },
                    { "group_count", TeacherCardItem.group_count.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "group_students_count", TeacherCardItem.group_students_count.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "lecture_hours", TeacherCardItem.lecture_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "lab_hours", TeacherCardItem.lab_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "practice_hours", TeacherCardItem.practice_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "exam_hours", TeacherCardItem.exam_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "zach_hours", TeacherCardItem.zach_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "zach_with_mark_hours", TeacherCardItem.zach_with_mark_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "course_project_hours", TeacherCardItem.course_project_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "course_task_hours", TeacherCardItem.course_task_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "control_task_hours", TeacherCardItem.control_task_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "referat_hours", TeacherCardItem.referat_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "essay_hours", TeacherCardItem.essay_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "head_of_practice_hours", TeacherCardItem.head_of_practice_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "head_of_vkr_hours", TeacherCardItem.head_of_vkr_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "iga_hours", TeacherCardItem.iga_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "nra_hours", TeacherCardItem.nra_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "nrm_hours", TeacherCardItem.nrm_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "teacher_card_id", TeacherCardItem.teacher_card_id.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                });

            return response;
        }

        public TeacherCardItem get(int id)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCardItem/" + id.ToString());

            TeacherCardItem result;

            try
            {
                result = JsonConvert.DeserializeObject<TeacherCardItem>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }

        public string update(TeacherCardItem TeacherCardItem, int id)
        {
            var response =
                ApiHelper.Post(ApiEndpoint + "/teacherCardItem/" + id.ToString(),
                new Dictionary<string, string>
                {
                    { "semester", TeacherCardItem.semester.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "code", TeacherCardItem.code },
                    { "discipline_name", TeacherCardItem.discipline_name },
                    { "group_name", TeacherCardItem.group_name },
                    { "group_count", TeacherCardItem.group_count.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "group_students_count", TeacherCardItem.group_students_count.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "lecture_hours", TeacherCardItem.lecture_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "lab_hours", TeacherCardItem.lab_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "practice_hours", TeacherCardItem.practice_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "exam_hours", TeacherCardItem.exam_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "zach_hours", TeacherCardItem.zach_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "zach_with_mark_hours", TeacherCardItem.zach_with_mark_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "course_project_hours", TeacherCardItem.course_project_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "course_task_hours", TeacherCardItem.course_task_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "control_task_hours", TeacherCardItem.control_task_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "referat_hours", TeacherCardItem.referat_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "essay_hours", TeacherCardItem.essay_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "head_of_practice_hours", TeacherCardItem.head_of_practice_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "head_of_vkr_hours", TeacherCardItem.head_of_vkr_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "iga_hours", TeacherCardItem.iga_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "nra_hours", TeacherCardItem.nra_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "nrm_hours", TeacherCardItem.nrm_hours.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                    { "teacher_card_id", TeacherCardItem.teacher_card_id.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) },
                });

            return response;
        }

        public string delete(int id)
        {
            var response =
                ApiHelper.Delete(ApiEndpoint + "/teacherCardItem/" + id.ToString(),
                new Dictionary<string, string>());

            return response;
        }

        public List<TeacherCardItem> teacherCardAll(int teacherCardId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCardItem/teacherCard/" + teacherCardId.ToString());

            List<TeacherCardItem> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<TeacherCardItem>>(StringResult);
            }
            catch (Exception e)
            {
                return null;
            }

            return result;
        }

        public List<TeacherCardItem> teacherAll(int teacherId)
        {
            var StringResult = ApiHelper.Get(ApiEndpoint + "/teacherCardItem/teacher/" + teacherId.ToString());

            List<TeacherCardItem> result;

            try
            {
                result = JsonConvert.DeserializeObject<List<TeacherCardItem>>(StringResult);
            }
            catch (Exception)
            {
                return null;
            }

            return result;
        }
    }
}
