using AutoMapper;

public class ClientMapper : Profile {
    public ClientMapper(){
        CreateMap<ClientInputModel, Client>();
        CreateMap<Client, ClientViewModel>();
    }
} 