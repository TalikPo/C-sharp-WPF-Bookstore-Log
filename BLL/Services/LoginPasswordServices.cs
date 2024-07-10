using BLL.Interfaces;
using BLL.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginPasswordServices : IMethodsBLL<BLLUserModel>
    {
        List<BLLUserModel> users;
        RegistryKey _key;
        string subkeyName;
        public LoginPasswordServices() 
        {
            users = new List<BLLUserModel>();
            _key = Registry.CurrentUser;
            subkeyName = "Book_Store";
        }
        public void add(BLLUserModel element)
        {
            try
            {
                bool isKey = false;
                foreach (string item in _key.GetSubKeyNames())
                {
                    if (item == subkeyName)
                    {
                        isKey = true;
                        break;
                    }
                }
                if (isKey == true)
                {
                    bool isKeyName = false;
                    foreach (string item in _key.OpenSubKey(subkeyName).GetValueNames())
                    {
                        if (item == element.UserName)
                        {
                            isKeyName = true;
                            break;
                        }
                    }
                    if (isKeyName == false)
                    {
                        _key.OpenSubKey(subkeyName, true).SetValue(element.UserName, element.UserPassword);
                    }
                }
                else if (isKey == false)
                {
                    _key.CreateSubKey(subkeyName);
                    _key.OpenSubKey(subkeyName, true).SetValue(element.UserName, element.UserPassword);
                }
                _key.Close();
            }
            catch (Exception excep)
            {
                throw new Exception(excep.Message);
            }
        }

        public void getAllfromDB()
        {
            foreach (string item in _key.GetSubKeyNames())
            {
                if (item == subkeyName)
                {
                    foreach (string username in _key.OpenSubKey(subkeyName).GetValueNames())
                    {
                        users.Add(new BLLUserModel { UserName = username, UserPassword = _key.OpenSubKey(subkeyName).GetValue(username).ToString() });
                    }
                }
            }
        }
        public void remove(BLLUserModel element)
        {
            try
            {
                foreach (string item in _key.GetSubKeyNames())
                {
                    if (item == subkeyName)
                    {
                        foreach (string name in _key.OpenSubKey(subkeyName).GetValueNames())
                        {
                            if (name == element.UserName)
                            {
                                _key.OpenSubKey(subkeyName).DeleteSubKey(name);
                                break;
                            }
                        }
                        break;
                    }
                }
                _key.Close();
            }
            catch (Exception excep)
            {
                throw new Exception(excep.Message);
            }
        }

        public List<BLLUserModel> returnAll()
        {
            return users;
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }

        public void update(BLLUserModel element)
        {
            try
            {
                foreach (string item in _key.OpenSubKey(subkeyName).GetValueNames())
                {
                    if (item == element.UserName)
                    {
                        _key.OpenSubKey(subkeyName, true).SetValue(element.UserName, element.UserPassword);
                    }
                }
                _key.Close();
            }
            catch (Exception excep)
            {
                throw new Exception(excep.Message);
            }
        }
    }
}
