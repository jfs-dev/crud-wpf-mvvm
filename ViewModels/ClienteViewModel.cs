using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using crud_wpf_mvvm.Data;
using crud_wpf_mvvm.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace crud_wpf_mvvm.ViewModels;

public partial class ClienteViewModel : ObservableObject, IDisposable
{
    protected readonly AppDbContext _context;

    public ObservableCollection<Cliente> Clientes { get ; set ; } = new();

    [ObservableProperty]
    public Cliente cliente = new();

    public Cliente ClienteEditMode { get ; set ; } = new();

    [ObservableProperty]
    public string hasErrorsCodeBehind = string.Empty;
    
    public ClienteViewModel()
    {
        _context = new AppDbContext();
    }

    [RelayCommand]
    public void New()
    {
        Cliente = new();        
    }

    [RelayCommand]
    public void EditModeOn()
    {
        ClienteEditMode.Nome = Cliente.Nome;
        ClienteEditMode.Email = Cliente.Email;
    }


    [RelayCommand]
    public void EditModeOff()
    {
        Cliente.Nome = ClienteEditMode.Nome;
        Cliente.Email = ClienteEditMode.Email;
    }

    [RelayCommand]
    public void Create()
    {
        try
        {
            HasErrorsCodeBehind = string.Empty;

            _context.Entry(Cliente).State = EntityState.Added;
            _context.SaveChanges();
        }
        catch (System.Exception ex)
        {
            HasErrorsCodeBehind = ex.Message;
        }
    }

    [RelayCommand]
    public void Edit()
    {
        try
        {
            HasErrorsCodeBehind = string.Empty;

            _context.Entry(Cliente).State = EntityState.Modified;
            _context.SaveChanges();
            
            EditModeOn();
        }
        catch (System.Exception ex)
        {
            HasErrorsCodeBehind = ex.Message;
        }
    }

    [RelayCommand]
    public void Delete()
    {
        try
        {
            HasErrorsCodeBehind = string.Empty;

            _context.Entry(Cliente).State = EntityState.Deleted;
            _context.SaveChanges();
        }
        catch (System.Exception ex)
        {
            HasErrorsCodeBehind = ex.Message;
        }
    }

    [RelayCommand]
    public void GetAll()
    {
        Clientes.Clear();

        foreach (var item in _context.Clientes.OrderBy(x => x.Id).ToList())
        {
            Clientes.Add(item);
        }
    }    

    public void Dispose()
    {
        _context.Dispose();
    }
}
