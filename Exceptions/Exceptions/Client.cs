using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public  class Client
    {
        public string Name { get; set; }
        public int Id { get; private set; }
        public Dictionary<int, string> clients = new Dictionary<int, string>();

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public Client()
        {
                
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"> A new client name </param>
        /// <param name="id"> A new client id </param>
        public Client(int id, string name)
        {
            this.Name = name;
            this.Id = id;
            this.clients.Add(id, name);
        }

        /// <summary>
        /// Add client
        /// </summary>
        /// <param name="name"> Client name </param>
        /// <param name="id"> Client id </param>
        public void Add(int id, string name)
        {
            if (!clients.Keys.Contains(id))
            {
                clients.Add(id, name);
            }
            else
            {
                throw new ClientException("Your client id is wrong");
            }
           
        }

        /// <summary>
        /// Find client by id
        /// </summary>
        /// <param name="id"> Client id </param>
        /// <returns> Client name </returns>
        public string FindClient(int id)
        {
            if (clients.Keys.Contains(id))
            {
                return clients[id];
            }
            else
            {
                throw new ClientException("Unable to find a client");
            }
        }
    }
}
