
using AutoMapper;
using ProyectoBack.Application.DTOs.v1;
using ProyectoBack.Application.DTOs.v1.POST;
using ProyectoBack.Application.DTOs.v1.PUT;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoBack.Application.Services.v1
{
    public class Servicio : IServicio
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Servicio(IUnitOfWork unitOfWork, IMapper e)
        {
            _mapper = e;
            _unitOfWork = unitOfWork;
        }

        public async Task<clsAspirante> crearAspirante(clsAspiranteDTO aspirante)
        {
            var validarCasa = _unitOfWork.clsCasa.GetById(aspirante.idCasa).Result;
            if (validarCasa == null) throw new Exception("La casa no existe");
            clsAspirante clsAspirante = _mapper.Map<clsAspirante>(aspirante);
            clsAspirante.fechaCreacion = DateTime.Now;
            await _unitOfWork.clsAspirante.Add(clsAspirante);
            await _unitOfWork.SaveChangesAsync();
            return clsAspirante;
        }
        public async Task<bool> eliminarAspirante(int id)
        {
            var aspiranteDB = _unitOfWork.clsAspirante.GetById(id).Result;
            if (aspiranteDB == null) throw new Exception("el aspirante no existe");
            await _unitOfWork.clsAspirante.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<List<clsAspirante>> obtenerAspirantes()
        {
            var data = await _unitOfWork.IServicioRepository.obtenerAspirantes();
            return data;
        }
        public async Task<clsAspirante> actualizarAspirante(clsAspirantePUT aspirante)
        {            
            var validarCasa = _unitOfWork.clsCasa.GetById(aspirante.idCasa).Result;
            if (validarCasa == null) throw new Exception("La casa no existe");
            var aspiranteDB = _unitOfWork.clsAspirante.GetById(aspirante.id).Result;
            if (aspiranteDB == null) throw new Exception("el aspirante no existe");
            aspiranteDB.fechaModificacion = DateTime.Now;
            aspiranteDB.nombre = aspiranteDB.nombre != aspirante.nombre ? (aspirante.nombre) : (aspiranteDB.nombre);
            aspiranteDB.apellido = aspiranteDB.apellido != aspirante.apellido ? (aspirante.apellido) : (aspiranteDB.apellido);
            aspiranteDB.edad = aspiranteDB.edad != aspirante.edad ? (aspirante.edad) : (aspiranteDB.edad);
            aspiranteDB.identificacion = aspiranteDB.identificacion != aspirante.identificacion ? (aspirante.identificacion) : (aspiranteDB.identificacion);
            aspiranteDB.idCasa = aspiranteDB.idCasa != aspirante.idCasa ? (aspirante.idCasa) : (aspiranteDB.idCasa);

            _unitOfWork.clsAspirante.Update(aspiranteDB);
            await _unitOfWork.SaveChangesAsync();
            return aspiranteDB;
        }

        public async Task<clsUsuario> crearUsuario(LoginModelDTO login)
        {
            var usuarioExistente = await _unitOfWork.IServicioRepository.obtenerUsuarios(login.usuario);
            if (usuarioExistente != null) throw new Exception("El usuario ya existe");            
            clsUsuario clsUsuario = new clsUsuario();
            var password = PasswordHash(login.password);
            clsUsuario.password = password;
            clsUsuario.usuario = login.usuario;
            clsUsuario.fechaCreacion = DateTime.Now;
            await _unitOfWork.clsUsuario.Add(clsUsuario);
            await _unitOfWork.SaveChangesAsync();
            return clsUsuario;
        }
        private static string PasswordHash(string password)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Concat(hash.Select(b => b.ToString("x3")));
        }
        public async Task<clsUsuario> obtenerUsuario(string usuario, string password)
        {

            var usu = await _unitOfWork.IServicioRepository.obtenerUsuarios(usuario);
            if (usu != null)
            {
                var passwordhash = PasswordHash(password);
                if (usu.password == passwordhash)
                {
                    return usu;
                }
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
