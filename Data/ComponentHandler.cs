﻿using MallMapsApi.Data.DTO;
using MallMapsApi.Interface;

namespace MallMapsApi.Data
{
    public class ComponentHandler : IComponent
    {
        /// <summary>
        /// DataMapper
        /// </summary>
        private DataMapper _mapper;
        /// <summary>
        /// DatabaseAccess
        /// </summary>
        private ICrudAcess _crudAcess;

        /// <summary>
        /// Handles all components
        /// </summary>
        /// <param name="crudAcess"></param>
        public ComponentHandler(ICrudAcess crudAcess)
        {
            _crudAcess = crudAcess;
        }

        /// <summary>
        /// GetChildren components based on mapid
        /// </summary>
        /// <param name="mapid"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Dictionary<string, object> GetById(int mapid)
        {
            try
            {
                //Creating an instance of datamapper
                _mapper = new DataMapper();
                //creating an dictionary
                Dictionary<string, object> searchObject = new Dictionary<string, object>();
                //adding search values 
                searchObject.Add("Mapid", mapid);
                //Fetching components from db
                List<Component> components = _crudAcess.Get<Component>(searchObject)?.ToList();
                //Map components
                Dictionary<string, object> data = _mapper.ComponentMapper(components);
                //return data if not null
                if (data != null)
                    return data;
                //return null
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
