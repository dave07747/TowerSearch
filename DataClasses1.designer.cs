﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TowerSearch
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Parts")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLog(Log instance);
    partial void UpdateLog(Log instance);
    partial void DeleteLog(Log instance);
    partial void InsertPart(Part instance);
    partial void UpdatePart(Part instance);
    partial void DeletePart(Part instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::TowerSearch.Properties.Settings.Default.PartsConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<Log> Logs
		{
			get
			{
				return this.GetTable<Log>();
			}
		}
		
		public System.Data.Linq.Table<Part> Parts
		{
			get
			{
				return this.GetTable<Part>();
			}
		}
		
		public System.Data.Linq.Table<PartsOut> PartsOuts
		{
			get
			{
				return this.GetTable<PartsOut>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[Log]")]
	public partial class Log : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _Grade;
		
		private string _PartName;
		
		private string _Quantity;
		
		private int _isOut;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnGradeChanging(string value);
    partial void OnGradeChanged();
    partial void OnPartNameChanging(string value);
    partial void OnPartNameChanged();
    partial void OnQuantityChanging(string value);
    partial void OnQuantityChanged();
    partial void OnisOutChanging(int value);
    partial void OnisOutChanged();
    #endregion
		
		public Log()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Grade", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Grade
		{
			get
			{
				return this._Grade;
			}
			set
			{
				if ((this._Grade != value))
				{
					this.OnGradeChanging(value);
					this.SendPropertyChanging();
					this._Grade = value;
					this.SendPropertyChanged("Grade");
					this.OnGradeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PartName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string PartName
		{
			get
			{
				return this._PartName;
			}
			set
			{
				if ((this._PartName != value))
				{
					this.OnPartNameChanging(value);
					this.SendPropertyChanging();
					this._PartName = value;
					this.SendPropertyChanged("PartName");
					this.OnPartNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isOut", DbType="int", UpdateCheck=UpdateCheck.WhenChanged)]
		public int isOut
		{
			get
			{
				return this._isOut;
			}
			set
			{
				if ((this._isOut != value))
				{
					this.OnisOutChanging(value);
					this.SendPropertyChanging();
					this._isOut = value;
					this.SendPropertyChanged("isOut");
					this.OnisOutChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Parts")]
	public partial class Part : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _PartName;
		
		private int _Tower;
		
		private int _Side;
		
		private int _XCoordinate;
		
		private int _YCoordinate;
		
		private int _Quantity;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPartNameChanging(string value);
    partial void OnPartNameChanged();
    partial void OnTowerChanging(int value);
    partial void OnTowerChanged();
    partial void OnSideChanging(int value);
    partial void OnSideChanged();
    partial void OnXCoordinateChanging(int value);
    partial void OnXCoordinateChanged();
    partial void OnYCoordinateChanging(int value);
    partial void OnYCoordinateChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    #endregion
		
		public Part()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PartName", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string PartName
		{
			get
			{
				return this._PartName;
			}
			set
			{
				if ((this._PartName != value))
				{
					this.OnPartNameChanging(value);
					this.SendPropertyChanging();
					this._PartName = value;
					this.SendPropertyChanged("PartName");
					this.OnPartNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tower", DbType="Int NOT NULL")]
		public int Tower
		{
			get
			{
				return this._Tower;
			}
			set
			{
				if ((this._Tower != value))
				{
					this.OnTowerChanging(value);
					this.SendPropertyChanging();
					this._Tower = value;
					this.SendPropertyChanged("Tower");
					this.OnTowerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Side", DbType="Int NOT NULL")]
		public int Side
		{
			get
			{
				return this._Side;
			}
			set
			{
				if ((this._Side != value))
				{
					this.OnSideChanging(value);
					this.SendPropertyChanging();
					this._Side = value;
					this.SendPropertyChanged("Side");
					this.OnSideChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XCoordinate", DbType="Int NOT NULL")]
		public int XCoordinate
		{
			get
			{
				return this._XCoordinate;
			}
			set
			{
				if ((this._XCoordinate != value))
				{
					this.OnXCoordinateChanging(value);
					this.SendPropertyChanging();
					this._XCoordinate = value;
					this.SendPropertyChanged("XCoordinate");
					this.OnXCoordinateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YCoordinate", DbType="Int NOT NULL")]
		public int YCoordinate
		{
			get
			{
				return this._YCoordinate;
			}
			set
			{
				if ((this._YCoordinate != value))
				{
					this.OnYCoordinateChanging(value);
					this.SendPropertyChanging();
					this._YCoordinate = value;
					this.SendPropertyChanged("YCoordinate");
					this.OnYCoordinateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this.OnQuantityChanging(value);
					this.SendPropertyChanging();
					this._Quantity = value;
					this.SendPropertyChanged("Quantity");
					this.OnQuantityChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PartsOut")]
	public partial class PartsOut
	{
		
		private int _Id;
		
		private string _FirstName;
		
		private string _LastName;
		
		private int _Grade;
		
		private string _PartName;
		
		private int _Quantity;
		
		private int _isOut;
		
		public PartsOut()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
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
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this._FirstName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this._LastName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Grade", DbType="Int NOT NULL")]
		public int Grade
		{
			get
			{
				return this._Grade;
			}
			set
			{
				if ((this._Grade != value))
				{
					this._Grade = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PartName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string PartName
		{
			get
			{
				return this._PartName;
			}
			set
			{
				if ((this._PartName != value))
				{
					this._PartName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
		public int Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this._Quantity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isOut", DbType="Int NOT NULL")]
		public int isOut
		{
			get
			{
				return this._isOut;
			}
			set
			{
				if ((this._isOut != value))
				{
					this._isOut = value;
				}
			}
		}
	}
}
#pragma warning restore 1591