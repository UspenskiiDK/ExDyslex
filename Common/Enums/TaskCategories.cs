using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    public enum TaskCategories
    {
        [Display(Name ="Задание с письменным ответом")]
        Задание_с_письменным_ответом,

        [Display(Name ="Задание с выбором варианта ответа")]
        Задание_с_выбором_варианта_ответа
    }
}
