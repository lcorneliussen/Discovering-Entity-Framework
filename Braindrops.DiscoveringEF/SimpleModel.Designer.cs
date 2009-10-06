﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

#region EDM Relationship Metadata
[assembly: EdmRelationshipAttribute("PeopleModel", "AllPeopleAllPeopleCars", "AllPeople", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Braindrops.DiscoveringEF.Person), "AllPeopleCars", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Braindrops.DiscoveringEF.Car))]
#endregion

namespace Braindrops.DiscoveringEF
{
    #region Contexts
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class PeopleModelConnection : ObjectContext
    {
        #region Constructors
        /// <summary>
        /// Initializes a new PeopleModelConnection object using the connection string found in the 'PeopleModelConnection' section of the application configuration file.
        /// </summary>
        public PeopleModelConnection() : base("name=PeopleModelConnection", "PeopleModelConnection")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new PeopleModelConnection object.
        /// </summary>
        public PeopleModelConnection(string connectionString) : base(connectionString, "PeopleModelConnection")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new PeopleModelConnection object.
        /// </summary>
        public PeopleModelConnection(EntityConnection connection) : base(connection, "PeopleModelConnection")
        {
            OnContextCreated();
        }
        #endregion
        
        #region Partial Methods
        partial void OnContextCreated();
        #endregion
        
        #region ObjectSet Properties
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Person> AllPeople
        {
            get
            {
                if ((_AllPeople == null))
                {
                    _AllPeople = base.CreateObjectSet<Person>("AllPeople");
                }
                return _AllPeople;
            }
        }
        private ObjectSet<Person> _AllPeople;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Car> AllCars
        {
            get
            {
                if ((_AllCars == null))
                {
                    _AllCars = base.CreateObjectSet<Car>("AllCars");
                }
                return _AllCars;
            }
        }
        private ObjectSet<Car> _AllCars;
    
        #endregion
        #region AddTo Methods
            
        /// <summary>
        /// Deprecated Method for adding a new object to the AllPeople EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAllPeople(Person person)
        {
            base.AddObject("AllPeople", person);
        }
            
        /// <summary>
        /// Deprecated Method for adding a new object to the AllCars EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAllCars(Car car)
        {
            base.AddObject("AllCars", car);
        }
        #endregion
    }
    
    #endregion
    
    
    #region Entities
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PeopleModel", Name="Car")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Car : EntityObject
    {
        #region Factory Method
        /// <summary>
        /// Create a new Car object.
        /// </summary>
        /// <param name="model">Initial value of the Model property.</param>
        /// <param name="id">Initial value of the Id property.</param>
        public static Car CreateCar(global::System.String model, global::System.Guid id)
        {
            Car car = new Car();
            car.Model = model;
            
            car.Id = id;
            
            return car;
        }
        #endregion

        #region Primitive Properties
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Model
        {
            get
            {
                return _Model;
            }
            set
            {
                OnModelChanging(value);
                ReportPropertyChanging("Model");
                _Model = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Model");
                OnModelChanged();
            }
                
        }
        private global::System.String _Model;
        partial void OnModelChanging(global::System.String value);
        partial void OnModelChanged();
        
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
                
        }
        private global::System.Guid _Id;
        partial void OnIdChanging(global::System.Guid value);
        partial void OnIdChanged();
        
        #endregion
    
        #region Navigation Properties
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PeopleModel", "AllPeopleAllPeopleCars", "AllPeople")] 
        public Person Person
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Person>("PeopleModel.AllPeopleAllPeopleCars", "AllPeople").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Person>("PeopleModel.AllPeopleAllPeopleCars", "AllPeople").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Person> PersonReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Person>("PeopleModel.AllPeopleAllPeopleCars", "AllPeople");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Person>("PeopleModel.AllPeopleAllPeopleCars", "AllPeople", value);
                }
            }
        }
        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PeopleModel", Name="Person")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Person : EntityObject
    {
        #region Factory Method
        /// <summary>
        /// Create a new Person object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="age">Initial value of the Age property.</param>
        public static Person CreatePerson(global::System.Guid id, global::System.String name, global::System.Int32 age)
        {
            Person person = new Person();
            person.Id = id;
            
            person.Name = name;
            
            person.Age = age;
            
            return person;
        }
        #endregion

        #region Primitive Properties
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
                
        }
        private global::System.Guid _Id;
        partial void OnIdChanging(global::System.Guid value);
        partial void OnIdChanged();
        
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
                
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
        
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Age
        {
            get
            {
                return _Age;
            }
            set
            {
                OnAgeChanging(value);
                ReportPropertyChanging("Age");
                _Age = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Age");
                OnAgeChanged();
            }
                
        }
        private global::System.Int32 _Age;
        partial void OnAgeChanging(global::System.Int32 value);
        partial void OnAgeChanged();
        
        #endregion
    
        #region Navigation Properties
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PeopleModel", "AllPeopleAllPeopleCars", "AllPeopleCars")] 
        public EntityCollection<Car> Cars
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Car>("PeopleModel.AllPeopleAllPeopleCars", "AllPeopleCars");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Car>("PeopleModel.AllPeopleAllPeopleCars", "AllPeopleCars", value);
                }
            }
        }
        #endregion
    }
    
    #endregion
    
}
