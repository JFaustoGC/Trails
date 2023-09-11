using System.Net.Http.Json;
using BlazingTrails.Shared.Features.ManageTrails.EditTrail;
using MediatR;

namespace BlazingTrails.Client.Features.ManageTrails.EditTrail;

public class EditTrailHandler : IRequestHandler<EditTrailRequest, EditTrailRequest.Response>
{
    private readonly HttpClient _httpClient;

    public EditTrailHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<EditTrailRequest.Response> Handle(EditTrailRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PutAsJsonAsync(EditTrailRequest.RouteTemplate, request, cancellationToken);

        return response.IsSuccessStatusCode
            ? new EditTrailRequest.Response(true)
            : new EditTrailRequest.Response(false);
    }
}