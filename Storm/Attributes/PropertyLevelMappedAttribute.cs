﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Storm.Attributes
{
	/// <summary>
	/// Base interface for all attributes that indicate that a property is mapped.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
	public abstract class PropertyLevelMappedAttribute : System.Attribute
	{
		public StormPersistenceEvents SupressEvents { get; set; }
		public PropertyInfo AttachedTo { get; set; }
		protected bool PreValidated { get; set; }
		protected bool PostValidated { get; set; }

		protected PropertyLevelMappedAttribute()
		{
		}

		/// <summary>
		/// Validate a peroperty's mapping before query execution.
		/// </summary>
		/// <param name="decoratedProperty">The Property that is mapped by this attribute.</param>
		/// <exception cref="StormConfigurationException">If mapping is invalid.</exception>
		internal virtual void ValidateMappingPre(PropertyInfo decoratedProperty)
		{
			if (this.PreValidated)
				return;

			this.AttachedTo = decoratedProperty;
			this.PreValidated = true;
		}

	}
}
