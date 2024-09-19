using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace InfoPortal.Host.Controllers.v1
{
    [Route("/v1/[controller]")]
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
