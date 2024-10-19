using Backend.Context;
using Backend.Models;
using System.Collections.Generic;
using System.Linq;
using Backend.Repository;

namespace Backend.Repository
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly AppDbContext _context;

        public ProposalRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Proposal> GetAll()
        {
            return _context.Proposals.ToList();
        }

        public Proposal GetById(int id)
        {
            return _context.Proposals.Find(id);
        }

        public void Add(Proposal proposal)
        {
            _context.Proposals.Add(proposal);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
