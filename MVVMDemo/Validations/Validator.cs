using MVVMDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Validations
{
    public class Validator<U>
    {
        private IValidation<U> _validation;
        private IErrorNotification _errorInform;
        public Validator(IValidation<U> validation)
        {
            _validation = validation;
        }

        public Validator(IErrorNotification errorNotification)
        {
            _errorInform = errorNotification;
        }

        public Validator<U> SetValidation(IValidation<U> validation)
        {
            _validation = validation;
            return this;
        }

        public Validator<U> SetErrorNotification(IErrorNotification errorNotification)
        {
            _errorInform = errorNotification;
            return this;
        }

        public U Validated(U data)
        {
            if (_validation == null)
                return data;

            U validatedData = _validation.Validated(data);

            if (validatedData == null)
                _errorInform?.InformError(_validation.GetNotifications());

            return validatedData;
        }
    }
}
