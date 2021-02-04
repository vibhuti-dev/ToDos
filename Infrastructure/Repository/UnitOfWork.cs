using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IToDoRepository ToDos {get;}
        public UnitOfWork(IToDoRepository todoRepository)
        {
            ToDos = todoRepository;
        }
       
    }
}