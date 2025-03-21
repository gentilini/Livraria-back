﻿using Livraria.Interfaces.Repositories;
using Livraria.Interfaces.Services;
using Livraria.Models;
using Livraria.ViewModels;

namespace Livraria.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ILivroAssuntoRepository _livroAssuntoRepository;
        private readonly ILivroAutorRepository _livroAutorRepository;
        private readonly ILivroFormaCompraRepository _livroFormaCompraRepository;

        public LivroService(ILivroRepository livroRepository, ILivroAssuntoRepository livroAssuntoRepository, ILivroAutorRepository livroAutorRepository, ILivroFormaCompraRepository livroFormaCompraRepository)
        {
            _livroRepository = livroRepository;
            _livroAssuntoRepository = livroAssuntoRepository;
            _livroAutorRepository = livroAutorRepository;
            _livroFormaCompraRepository = livroFormaCompraRepository;
        }

        public async Task<int> CreateAsync(LivroRequestViewModel livroRequestViewModel)
        {
            // Criar a Livro e retornar o código criado
            var model = new LivroModel
            {
                Codl = livroRequestViewModel.Livro.Codl,
                Titulo = livroRequestViewModel.Livro.Titulo,
                Editora = livroRequestViewModel.Livro.Editora,
                Edicao = livroRequestViewModel.Livro.Edicao,
                AnoPublicacao = livroRequestViewModel.Livro.AnoPublicacao
            };

            var id = await _livroRepository.CreateAsync(model);

            // Criar a LivroAssunto
            foreach (var assunto in livroRequestViewModel.Livro.Assuntos)
            {
                var livroAssuto = new LivroAssunto
                {
                    LivroCodL = id,
                    AssuntoCodAs = assunto
                };

                await _livroAssuntoRepository.CreateAsync(livroAssuto);
            }

            // Criar a LivroAutor
            foreach (var autor in livroRequestViewModel.Livro.Autores)
            {
                var livroAutor = new LivroAutor
                {
                    LivroCodL = id,
                    AutorCodAu = autor
                };

                await _livroAutorRepository.CreateAsync(livroAutor);
            }

            // Criar a LivroFormaCompra
            foreach (var formaCompra in livroRequestViewModel.Livro.Precos)
            {
                var livroFormaCompra = new LivroFormaCompra
                {
                    LivroCodL = id,
                    Preco = formaCompra.preco,
                    FormaCompraCodFo = formaCompra.CodFo
                };

                await _livroFormaCompraRepository.CreateAsync(livroFormaCompra);
            }

            return id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _livroRepository.DeleteAsync(id);

            return result > 0;
        }

        public async Task<IEnumerable<LivroResponseViewModel>> GetAllAsync()
        {
            return await _livroRepository.GetAllAsync();
        }

        public async Task<LivroResponseViewModel> GetByIdAsync(int id)
        {
            return await _livroRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(LivroRequestViewModel livroRequestViewModel)
        {
            // Atualiza o Livro e retornar o código criado
            var id = await _livroRepository.UpdateAsync(new LivroModel {
                 Codl = livroRequestViewModel.Livro.Codl, 
                 Titulo = livroRequestViewModel.Livro.Titulo,
                 Editora = livroRequestViewModel.Livro.Editora,
                 Edicao = livroRequestViewModel.Livro.Edicao,
                 AnoPublicacao = livroRequestViewModel.Livro.AnoPublicacao
            });

            // Apaga a LivroAssunto
            await _livroAssuntoRepository.DeleteAsync(id);
            // Apaga a LivroAutor
            await _livroAutorRepository.DeleteAsync(id);
            // Apaga a LivroFormaCompra
            await _livroFormaCompraRepository.DeleteAsync(id);
            // Criar a LivroAssunto
            foreach (var livroAssnto in livroRequestViewModel.Livro.Assuntos)
            {
                await _livroAssuntoRepository.CreateAsync(new LivroAssunto { LivroCodL = id, AssuntoCodAs = livroAssnto });
            }
            // Criar a LivroAutor
            foreach (var livroAutor in livroRequestViewModel.Livro.Autores)
            {
                await _livroAutorRepository.CreateAsync(new LivroAutor { LivroCodL = id, AutorCodAu = livroAutor });
            }
            // Criar a LivroFormaCompra
            foreach (var livroFormaCompra in livroRequestViewModel.Livro.Precos)
            {
                await _livroFormaCompraRepository.CreateAsync(new LivroFormaCompra { LivroCodL = id, FormaCompraCodFo = livroFormaCompra.CodFo, Preco = livroFormaCompra.preco });
            }

            return id > 0;
        }
    }
}
