using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vattenfall_IT_test.Models;

namespace Vattenfall_IT_test.Data
{
    public class DBFooLogic
    {
        DataContext db = null;
        public DBFooLogic()
        {
            this.db = new DataContext();
        }

        // gets the list of foo's
        public List<FooModels> GetFoos()
        {
            return db.Foos.ToList();
        }

        // get foo @ Id
        public FooModels GetFoo(Guid Id)
        {
            return db.Foos.FirstOrDefault(a => a.Id == Id);
        }

        // save entery of foo
        public FooModels SaveFoo(FooModels model)
        {
            model.Created = DateTime.Now;
            db.Foos.Add(model);
            db.SaveChanges();
            return model;
        }

        // edit foo entery
        public FooModels EditFoo(FooModels model)
        {
            FooModels originalFoo = db.Foos.FirstOrDefault(a => a.Id == model.Id);
            if(originalFoo != null)
            {
                originalFoo.Modified = DateTime.Now;
                originalFoo.Name = model.Name;
                originalFoo.Surename = model.Surename;
                originalFoo.Age = model.Age;
                db.Foos.Attach(originalFoo);
                db.Entry(originalFoo).State = EntityState.Modified;

                db.SaveChanges();
            }

            return originalFoo;
        }

        // delete foo entery
        public FooModels DeleteFoo(FooModels model)
        {
            FooModels originalFoo = db.Foos.FirstOrDefault(a => a.Id == model.Id);
            if (originalFoo != null)
            {
                db.Foos.Remove(originalFoo);
                db.SaveChanges();
            }
            return originalFoo;
        }

    }
}
