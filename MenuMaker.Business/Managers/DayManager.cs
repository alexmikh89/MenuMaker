using AutoMapper;
using MenuMaker.Business.Interfaces;
using MenuMaker.Business.Models;
using MenuMaker.Data.Interfaces;
using MenuMaker.Data.Models;
using System.Collections.Generic;

namespace MenuMaker.Business.Managers
{
    public class DayManager : IDayManager
    {
        protected readonly IMapper _mapper;
        protected readonly INextRepository<Day, int> _dayRepository;

        public DayManager(IMapper mapper, INextRepository<Day, int> dayRepository)
        {
            _mapper = mapper;
            _dayRepository = dayRepository;
        }

        public IEnumerable<DayModel> GetAll()
        {
            var dayList = _dayRepository.GetAll();
            var dayModelsList = _mapper.Map<IEnumerable<DayModel>>(dayList);
            return dayModelsList;
        }

        public DayModel FindById(int id)
        {
            var day = _dayRepository.FindById(id);
            var result = _mapper.Map<DayModel>(day);
            return result;
        }
    }
}
