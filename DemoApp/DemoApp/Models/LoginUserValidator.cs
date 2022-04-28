using FluentValidation;

namespace DemoApp.Models
{
    public class LoginUserValidator : AbstractValidator<LoginUser>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("请输入账号")
                .Length(5, 20).WithMessage("账号长度在5到20个字符之间");
            RuleFor(x => x.Password).NotEmpty().WithMessage("请输入密码");
        }
    }
}
