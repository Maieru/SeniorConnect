﻿using Microsoft.EntityFrameworkCore;
using Negocio.Database;
using Negocio.Helpers;
using Negocio.Model;
using Negocio.Repository.Assinatura;
using Negocio.Repository.Medicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Repository.Usuario
{
    public class UsuarioRepository : BaseEntityRepository, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<UsuarioModel>> GetAll() => await _applicationContext.Usuarios.ToListAsync();

        public async Task<UsuarioModel?> GetById(int id) => await _applicationContext.Usuarios.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<int> Insert(UsuarioModel usuario)
        {
            if (!await VerificaSeAssinaturaExiste(usuario.AssinaturaId))
                throw new ArgumentException("Assinatura não encontrada");

            if (string.IsNullOrEmpty(usuario.SenhaPlain))
                throw new ArgumentException("A senha não pode ser vazia.");

            if (await _applicationContext.Usuarios.AnyAsync(u => u.Usuario == usuario.Usuario))
                throw new ArgumentException("Esse usuário já existe.");

            usuario.Senha = await EncryptionHelper.Criptografa(usuario.SenhaPlain);
            usuario.SenhaPlain = null;
            await _applicationContext.Usuarios.AddAsync(usuario);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Update(UsuarioModel usuario)
        {
            if (!await _applicationContext.Usuarios.AnyAsync(p => p.Id == usuario.Id))
                return 0;

            if (!await VerificaSeAssinaturaExiste(usuario.AssinaturaId))
                throw new ArgumentException("Assinatura não encontrada");

            _applicationContext.Usuarios.Update(usuario);
            return await _applicationContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var usuario = await GetById(id);

            if (usuario == null)
                return 0;

            _applicationContext.Usuarios.Remove(usuario);
            return await _applicationContext.SaveChangesAsync();
        }
        
        public async Task<UsuarioModel> GetByUserAndPassword(string usuario, string senhaPlain)
        {
            var usuarioModel = await _applicationContext.Usuarios.FirstOrDefaultAsync(u => u.Usuario == usuario);

            if (usuarioModel == null)
                throw new ArgumentException("O usuário informado não existe");

            if (!await EncryptionHelper.VerificaSenha(senhaPlain, usuarioModel.Senha))
                throw new ArgumentException("A senha informada não corresponde ao usuário");

            return usuarioModel;
        }

        public async Task<UsuarioModel> GetByAssinatura(int assinatura) => await _applicationContext.Usuarios.Where(u => u.AssinaturaId == assinatura).FirstOrDefaultAsync();

        private async Task<bool> VerificaSeAssinaturaExiste(int assinaturaId)
        {
            var assinaturaRepository = new AssinaturaRepository(_applicationContext);
            return await assinaturaRepository.GetById(assinaturaId) != null;
        }
    }
}
