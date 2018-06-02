///////////////////////////////////////////////////////////
//  Description.cs
//  Implementation of the Class Description
//  Generated by Enterprise Architect
//  Created on:      22-May-2018 5:42:52 PM
//  Original author: Saska
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Description
{
    private int _dataset;
    private int _id;
    public List<Modul1Property> _m1Property = new List<Modul1Property>();


    public Description()
    {
        _m1Property = new List<Modul1Property>();
    }

    public Description(List<Modul1Property> m1p)
    {
        this._m1Property = m1p;
    }

    #region Getters / Setters
    public int Dataset
    {
        get
        {
            return _dataset;
        }
        set
        {
            _dataset = value;
        }
    }

    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

    #endregion Getters / Setters

    public bool AddValue(Modul1Property property)
    {
        if (property == null)
        {
            throw new ArgumentNullException("'property' ne moze biti null");
        }

        try
        {
            bool containsCode = false;

            foreach (Modul1Property dp in _m1Property)
            {
                if (dp.Code == property.Code)
                {
                    containsCode = true;
                    dp.Value = property.Value;
                    break;
                }
            }

            if (!containsCode)
            {
                _m1Property.Add(property);
            }

            return _m1Property.Count == 2;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}