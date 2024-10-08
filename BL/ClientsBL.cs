﻿using DAL;
using DAL.DbModels;
using Entities;
using Client = Entities.Client;
using Task = System.Threading.Tasks.Task;

namespace BL
{
    public class ClientsBL
    {
        public async Task CreateClient(Client client)
        {
            await new ClientsDAL().CreateClient(client);
        }

        public async Task UpdateClient(Client client)
        {
            await new ClientsDAL().UpdateClient(client);
        }

        public async Task DeleteClient(Client client)
        {
            await new ClientsDAL().DeleteClient(client);
        }

        public async Task<Client?> GetClientByEmail(string email)
        {
            return await new ClientsDAL().GetClientByEmail(email);
        }

        public async Task<Client?> GetClientById(int clientId)
        {
            return await new ClientsDAL().GetClientById(clientId);
        }
        public async Task<List<Client?>> GetAllClients()
        {
            return await new ClientsDAL().GetAllClients();
        }
    }
}
