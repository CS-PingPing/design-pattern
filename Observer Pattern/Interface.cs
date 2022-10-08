using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Practice.ObserverPattern
{
    public interface Subject
    {
        void registerObserver(Observer o);
        void removeObserver(Observer o);
        void notifyObserver();
    }
    public interface Observer
    {
        void update(float temp, float humidity, float pressure);
    }
    public interface DisplayElement
    {
        void display();
    }
}
