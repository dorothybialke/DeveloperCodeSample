using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain
{
    public class DoughnutMaker
    {
        private IDoughnutContext _doughnutSupply;
       
        public DoughnutMaker(IDoughnutContext doughnutSupply)
        {
            _doughnutSupply = doughnutSupply;
        }

        public List<Doughnut> DoughnutList()
        {
            return _doughnutSupply.Doughnuts.ToList();
        }

        public DeleteDoughnutResponse DeleteDoughnut (int Id)
        {
            DeleteDoughnutResponse response = new DeleteDoughnutResponse();
            Doughnut toRemove = _doughnutSupply.Doughnuts.Find(Id);
            if (toRemove== null)
            {
                response.Success = false;
                response.Message = "No Doughnuts Found.";
                return response;
            }
            _doughnutSupply.Doughnuts.Remove(toRemove);
            _doughnutSupply.SaveChanges();//do this after every change add delete edit
            response.Success = _doughnutSupply.Doughnuts.Find(Id) == null;
            response.DeleteDoughnut = toRemove;
            return response;
        }

        public SaveDoughnutResponse SaveDoughnut(Doughnut doughnut)
        {
            SaveDoughnutResponse response = new SaveDoughnutResponse();
            Doughnut toAdd = _doughnutSupply.Doughnuts.Add(doughnut);
            if (string.IsNullOrWhiteSpace(toAdd.Name))  
            {
                    response.Success = false;
                    response.Message = "You need to name your doughnut... be creative.";
                    return response;
                }
            List<Doughnut> doughnutList = DoughnutList();
            _doughnutSupply.Doughnuts.Add(toAdd);
            _doughnutSupply.SaveChanges();
            response.Success = true;
            response.SaveDoughnut = toAdd;
            return response;
        }



    }
}
