using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

       public IToDoRepository ToDo {get;}
        public UnitOfWork(IToDoRepository todoRepository)
        {
            ToDo = todoRepository;
        }
       
    }
}