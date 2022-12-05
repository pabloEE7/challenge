using MediatR;
using WebApplication.Application.Queries;
using WebApplication.Domain.Entities;
using WebApplication.Application.DTOs;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace WebApplication.Application.Queries
{
    public class GetServerPostByIdQuery: IRequest<ServerPostDto>
    {
        public int Id { get; set; }
        public class GetServerPostByIdHandler : IRequestHandler<GetServerPostByIdQuery, ServerPostDto>
        {
            private readonly IMapper _mapper;
            public GetServerPostByIdHandler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task<ServerPostDto> Handle(GetServerPostByIdQuery request, CancellationToken cancellationToken)
            {
                var client = new HttpClient();

                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
                var content = await response.Content.ReadAsStringAsync();
                var ServerPost = JsonSerializer.Deserialize<List<ServerPost>>(content);

                var responseServerPost = ServerPost.Where(s => s.id == request.Id).FirstOrDefault();

                var ServerPostDto = _mapper.Map<ServerPostDto>(responseServerPost);

                if (ServerPostDto != null)
                    return await Task.FromResult(ServerPostDto);
                else
                    return null;
            }
        }
    }
}
