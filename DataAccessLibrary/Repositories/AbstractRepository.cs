using LibraryManagement.BuisnessLayerLibrary.Interfaces;
using LibraryManagement.DataAccessLibrary.DBContext;
using Microsoft.EntityFrameworkCore;

namespace NotificationAppDataAccessLibrary.Repositories;

public abstract class AbstractRepository<K, T> : IRepository<K, T> where T : class, new() where K : notnull
{
    protected readonly LibraryManagementContext libraryManagementContext;
    public AbstractRepository()
    {
        libraryManagementContext = new LibraryManagementContext();
    }

    // Get the details of the tables by id
    public T Create(T item)
    {
        
            libraryManagementContext.Add(item);
            libraryManagementContext.SaveChanges();
            return item;
    
        
    }

    public List<T> GetAll()
    {
        return libraryManagementContext.Set<T>().ToList();
    }
}