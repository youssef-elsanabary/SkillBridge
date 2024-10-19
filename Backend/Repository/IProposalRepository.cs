using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IProposalRepository
    {
        List<Proposal> GetAll();
        Proposal GetById(int id);
        void Add(Proposal proposal);
        bool SaveChanges();
    }
}
