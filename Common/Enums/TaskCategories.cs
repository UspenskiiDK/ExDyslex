using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    enum TaskCategories
    {
        [Display(Name ="Задание с письменным ответом")]
        TextQuestion,

        [Display(Name ="Задание с выбором варианта ответа")]
        ChooseQuestion
    }
}
