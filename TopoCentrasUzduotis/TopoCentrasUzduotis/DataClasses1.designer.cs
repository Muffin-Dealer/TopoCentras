#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TopoCentrasUzduotis
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TopoCentrasDB")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertKlientai(Klientai instance);
    partial void UpdateKlientai(Klientai instance);
    partial void DeleteKlientai(Klientai instance);
    partial void InsertUzsakymai(Uzsakymai instance);
    partial void UpdateUzsakymai(Uzsakymai instance);
    partial void DeleteUzsakymai(Uzsakymai instance);
    partial void InsertPirkiniuSarasa(PirkiniuSarasa instance);
    partial void UpdatePirkiniuSarasa(PirkiniuSarasa instance);
    partial void DeletePirkiniuSarasa(PirkiniuSarasa instance);
    partial void InsertPrekes(Prekes instance);
    partial void UpdatePrekes(Prekes instance);
    partial void DeletePrekes(Prekes instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::TopoCentrasUzduotis.Properties.Settings.Default.TopoCentrasDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Klientai> Klientais
		{
			get
			{
				return this.GetTable<Klientai>();
			}
		}
		
		public System.Data.Linq.Table<Uzsakymai> Uzsakymais
		{
			get
			{
				return this.GetTable<Uzsakymai>();
			}
		}
		
		public System.Data.Linq.Table<PirkiniuSarasa> PirkiniuSarasas
		{
			get
			{
				return this.GetTable<PirkiniuSarasa>();
			}
		}
		
		public System.Data.Linq.Table<Prekes> Prekes
		{
			get
			{
				return this.GetTable<Prekes>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Klientai")]
	public partial class Klientai : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Pavadinimas;
		
		private EntitySet<Uzsakymai> _Uzsakymais;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPavadinimasChanging(string value);
    partial void OnPavadinimasChanged();
    #endregion
		
		public Klientai()
		{
			this._Uzsakymais = new EntitySet<Uzsakymai>(new Action<Uzsakymai>(this.attach_Uzsakymais), new Action<Uzsakymai>(this.detach_Uzsakymais));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pavadinimas", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Pavadinimas
		{
			get
			{
				return this._Pavadinimas;
			}
			set
			{
				if ((this._Pavadinimas != value))
				{
					this.OnPavadinimasChanging(value);
					this.SendPropertyChanging();
					this._Pavadinimas = value;
					this.SendPropertyChanged("Pavadinimas");
					this.OnPavadinimasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Klientai_Uzsakymai", Storage="_Uzsakymais", ThisKey="Id", OtherKey="Uzsakovas")]
		public EntitySet<Uzsakymai> Uzsakymais
		{
			get
			{
				return this._Uzsakymais;
			}
			set
			{
				this._Uzsakymais.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Uzsakymais(Uzsakymai entity)
		{
			this.SendPropertyChanging();
			entity.Klientai = this;
		}
		
		private void detach_Uzsakymais(Uzsakymai entity)
		{
			this.SendPropertyChanging();
			entity.Klientai = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Uzsakymai")]
	public partial class Uzsakymai : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UzsakymoId;
		
		private int _Uzsakovas;
		
		private EntitySet<PirkiniuSarasa> _PirkiniuSarasas;
		
		private EntityRef<Klientai> _Klientai;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUzsakymoIdChanging(int value);
    partial void OnUzsakymoIdChanged();
    partial void OnUzsakovasChanging(int value);
    partial void OnUzsakovasChanged();
    #endregion
		
		public Uzsakymai()
		{
			this._PirkiniuSarasas = new EntitySet<PirkiniuSarasa>(new Action<PirkiniuSarasa>(this.attach_PirkiniuSarasas), new Action<PirkiniuSarasa>(this.detach_PirkiniuSarasas));
			this._Klientai = default(EntityRef<Klientai>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UzsakymoId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UzsakymoId
		{
			get
			{
				return this._UzsakymoId;
			}
			set
			{
				if ((this._UzsakymoId != value))
				{
					this.OnUzsakymoIdChanging(value);
					this.SendPropertyChanging();
					this._UzsakymoId = value;
					this.SendPropertyChanged("UzsakymoId");
					this.OnUzsakymoIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Uzsakovas", DbType="Int NOT NULL")]
		public int Uzsakovas
		{
			get
			{
				return this._Uzsakovas;
			}
			set
			{
				if ((this._Uzsakovas != value))
				{
					if (this._Klientai.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUzsakovasChanging(value);
					this.SendPropertyChanging();
					this._Uzsakovas = value;
					this.SendPropertyChanged("Uzsakovas");
					this.OnUzsakovasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Uzsakymai_PirkiniuSarasa", Storage="_PirkiniuSarasas", ThisKey="UzsakymoId", OtherKey="Uzsakymas")]
		public EntitySet<PirkiniuSarasa> PirkiniuSarasas
		{
			get
			{
				return this._PirkiniuSarasas;
			}
			set
			{
				this._PirkiniuSarasas.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Klientai_Uzsakymai", Storage="_Klientai", ThisKey="Uzsakovas", OtherKey="Id", IsForeignKey=true)]
		public Klientai Klientai
		{
			get
			{
				return this._Klientai.Entity;
			}
			set
			{
				Klientai previousValue = this._Klientai.Entity;
				if (((previousValue != value) 
							|| (this._Klientai.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Klientai.Entity = null;
						previousValue.Uzsakymais.Remove(this);
					}
					this._Klientai.Entity = value;
					if ((value != null))
					{
						value.Uzsakymais.Add(this);
						this._Uzsakovas = value.Id;
					}
					else
					{
						this._Uzsakovas = default(int);
					}
					this.SendPropertyChanged("Klientai");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PirkiniuSarasas(PirkiniuSarasa entity)
		{
			this.SendPropertyChanging();
			entity.Uzsakymai = this;
		}
		
		private void detach_PirkiniuSarasas(PirkiniuSarasa entity)
		{
			this.SendPropertyChanging();
			entity.Uzsakymai = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PirkiniuSarasas")]
	public partial class PirkiniuSarasa : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Uzsakymas;
		
		private int _Preke;
		
		private EntityRef<Uzsakymai> _Uzsakymai;
		
		private EntityRef<Prekes> _Prekes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUzsakymasChanging(int value);
    partial void OnUzsakymasChanged();
    partial void OnPrekeChanging(int value);
    partial void OnPrekeChanged();
    #endregion
		
		public PirkiniuSarasa()
		{
			this._Uzsakymai = default(EntityRef<Uzsakymai>);
			this._Prekes = default(EntityRef<Prekes>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Uzsakymas", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Uzsakymas
		{
			get
			{
				return this._Uzsakymas;
			}
			set
			{
				if ((this._Uzsakymas != value))
				{
					if (this._Uzsakymai.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUzsakymasChanging(value);
					this.SendPropertyChanging();
					this._Uzsakymas = value;
					this.SendPropertyChanged("Uzsakymas");
					this.OnUzsakymasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Preke", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Preke
		{
			get
			{
				return this._Preke;
			}
			set
			{
				if ((this._Preke != value))
				{
					if (this._Prekes.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPrekeChanging(value);
					this.SendPropertyChanging();
					this._Preke = value;
					this.SendPropertyChanged("Preke");
					this.OnPrekeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Uzsakymai_PirkiniuSarasa", Storage="_Uzsakymai", ThisKey="Uzsakymas", OtherKey="UzsakymoId", IsForeignKey=true)]
		public Uzsakymai Uzsakymai
		{
			get
			{
				return this._Uzsakymai.Entity;
			}
			set
			{
				Uzsakymai previousValue = this._Uzsakymai.Entity;
				if (((previousValue != value) 
							|| (this._Uzsakymai.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Uzsakymai.Entity = null;
						previousValue.PirkiniuSarasas.Remove(this);
					}
					this._Uzsakymai.Entity = value;
					if ((value != null))
					{
						value.PirkiniuSarasas.Add(this);
						this._Uzsakymas = value.UzsakymoId;
					}
					else
					{
						this._Uzsakymas = default(int);
					}
					this.SendPropertyChanged("Uzsakymai");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Prekes_PirkiniuSarasa", Storage="_Prekes", ThisKey="Preke", OtherKey="Id", IsForeignKey=true)]
		public Prekes Prekes
		{
			get
			{
				return this._Prekes.Entity;
			}
			set
			{
				Prekes previousValue = this._Prekes.Entity;
				if (((previousValue != value) 
							|| (this._Prekes.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Prekes.Entity = null;
						previousValue.PirkiniuSarasas.Remove(this);
					}
					this._Prekes.Entity = value;
					if ((value != null))
					{
						value.PirkiniuSarasas.Add(this);
						this._Preke = value.Id;
					}
					else
					{
						this._Preke = default(int);
					}
					this.SendPropertyChanged("Prekes");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Prekes")]
	public partial class Prekes : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Pavadinimass;
		
		private System.Nullable<decimal> _Kaina;
		
		private EntitySet<PirkiniuSarasa> _PirkiniuSarasas;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPavadinimassChanging(string value);
    partial void OnPavadinimassChanged();
    partial void OnKainaChanging(System.Nullable<decimal> value);
    partial void OnKainaChanged();
    #endregion
		
		public Prekes()
		{
			this._PirkiniuSarasas = new EntitySet<PirkiniuSarasa>(new Action<PirkiniuSarasa>(this.attach_PirkiniuSarasas), new Action<PirkiniuSarasa>(this.detach_PirkiniuSarasas));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pavadinimass", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Pavadinimass
		{
			get
			{
				return this._Pavadinimass;
			}
			set
			{
				if ((this._Pavadinimass != value))
				{
					this.OnPavadinimassChanging(value);
					this.SendPropertyChanging();
					this._Pavadinimass = value;
					this.SendPropertyChanged("Pavadinimass");
					this.OnPavadinimassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Kaina", DbType="Decimal(12,2)")]
		public System.Nullable<decimal> Kaina
		{
			get
			{
				return this._Kaina;
			}
			set
			{
				if ((this._Kaina != value))
				{
					this.OnKainaChanging(value);
					this.SendPropertyChanging();
					this._Kaina = value;
					this.SendPropertyChanged("Kaina");
					this.OnKainaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Prekes_PirkiniuSarasa", Storage="_PirkiniuSarasas", ThisKey="Id", OtherKey="Preke")]
		public EntitySet<PirkiniuSarasa> PirkiniuSarasas
		{
			get
			{
				return this._PirkiniuSarasas;
			}
			set
			{
				this._PirkiniuSarasas.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_PirkiniuSarasas(PirkiniuSarasa entity)
		{
			this.SendPropertyChanging();
			entity.Prekes = this;
		}
		
		private void detach_PirkiniuSarasas(PirkiniuSarasa entity)
		{
			this.SendPropertyChanging();
			entity.Prekes = null;
		}
	}
}
#pragma warning restore 1591
