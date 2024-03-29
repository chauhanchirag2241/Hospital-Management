﻿using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Infrastructure
{
    public interface IPaitentRepository
    {
        public Task<List<paitent>> GetAll();
        public Task<List<paitent>> GetPaitentByPaitentId(int paitentId);
        public Task<int> createPaitent(paitent paitent);
    }
}
