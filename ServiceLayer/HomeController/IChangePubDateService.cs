// Copyright (c) 2018 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using DataLayer.EfClasses.CrUDOnly;
using GenericServices;
using ServiceLayer.HomeController.Dtos;

namespace ServiceLayer.HomeController
{
    public interface IChangePubDateService : IStatusGeneric
    {
        ChangePubDateDto GetOriginal(int id);
        Book UpdateBook(int id, ChangePubDateDto dto);
    }
}