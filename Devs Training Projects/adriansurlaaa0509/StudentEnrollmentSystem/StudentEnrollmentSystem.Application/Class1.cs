using MediatR;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Atilla.Application.Admin.Queries;
using Atilla.Domain.Entities.Tables;
using Atilla.Domain.Enums;
using Atilla.Application.Food.Commands;
using Atilla.Application.Food.Queries;
using Atilla.Domain.Entities;
using Atilla.Domain.Entities.Enums;
using Attila.Application.Inventory_Manager.Equipment.Commands;
using Attila.Application.Inventory_Manager.Equipment.Queries;
using Attila.Application.Inventory_Manager.Food.Commands;

namespace Attila.Presentation.InventoryManager
{
    public class Program
    {
        private const string V = "2";

        static IMediator Mediator
        {
            get
            {
                return ServiceRegistration.ServiceProvider.GetService<IMediator>();
            }
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Inventory Manager");
            Console.WriteLine();
            Console.WriteLine("1 - Food");
            Console.WriteLine("2 - Equipment");

        start:
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Please enter a command: ");
            string _cmdNumber = Console.ReadLine();

            switch (_cmdNumber)
            {
                case "1":

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Food Commands");
                    Console.WriteLine();
                    Console.WriteLine("1 - Add Food Details");
                    Console.WriteLine("2 - Add Food Inventory");
                    Console.WriteLine("3 - View Food Details");
                    Console.WriteLine("4 - View Food Stock");
                    Console.WriteLine("5 - Update Food Details");
                    Console.WriteLine("6 - Update Food Stock");
                    Console.WriteLine("7 - Delete Food Details");
                    Console.WriteLine("8 - Request Food Restock Delivery");
                    Console.WriteLine("9 - Search Food By ID");
                    Console.WriteLine("10 - Search Food By Keyword");

                foodsubstart:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Please enter a sub command: ");
                    string _subCmdNumberFood = Console.ReadLine();

                    switch (_subCmdNumberFood)
                    {
                        //case 1 : Add Food Details Command
                        #region  Add Food Details Command
                        case "1":

                            Console.WriteLine("Add Food Stock Details");
                            Console.WriteLine();

                            Console.Write("Food Code: ");
                            var _foodCode = Console.ReadLine();

                            Console.Write("Food Name: ");
                            var _foodName = Console.ReadLine();

                            Console.Write("Food Specification: ");
                            var _foodSpecification = Console.ReadLine();

                            Console.Write("Food Description: ");
                            var _foodDescription = Console.ReadLine();

                            Console.WriteLine("Food Unit: ");
                            Console.WriteLine("1 - Piece");
                            Console.WriteLine("2 - Box");
                            Console.WriteLine("3 - Dozen");
                            Console.WriteLine("4 - Others");
                            Console.Write("Food Unit: ");
                            var _foodUnit = Console.ReadLine();
                            UnitType _parsedfoodUnit = (UnitType)Enum.Parse(typeof(UnitType), _foodUnit);

                            Console.WriteLine("Food Type: ");
                            Console.WriteLine("1 - Perishable");
                            Console.WriteLine("2 - Non-perishable");
                            Console.WriteLine("3 - Others");
                            Console.Write("Food Type: ");
                            var _foodType = Console.ReadLine();
                            FoodType _parsedFoodType = (FoodType)Enum.Parse(typeof(FoodType), _foodType);


                            FoodDetails _foodDetails = new FoodDetails
                            {
                                Code = _foodCode,
                                Name = _foodName,
                                Specification = _foodSpecification,
                                Description = _foodDescription,
                                Unit = _parsedfoodUnit,
                                FoodType = _parsedFoodType
                            };

                            var _addFoodDetailsInventoryCommand = await Mediator.Send(new AddFoodDetailsCommand { MyFoodDetails = _foodDetails });
                            if (_addFoodDetailsInventoryCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Details Added to Inventory!");
                            }

                            goto foodsubstart;
                        #endregion

                        //case 2 : Add Food Inventory Command
                        #region Add Food Inventory Command
                        case "2":

                            Console.WriteLine();
                            var _viewFoodDetails = await Mediator.Send(new ViewFoodDetailsQuery());

                            foreach (var item in _viewFoodDetails)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:     {0}", item.ID);
                                Console.WriteLine("Food Name:           {0}", item.Name);
                                Console.WriteLine("Food Code:           {0}", item.Code);
                                Console.WriteLine("Food Specification:  {0}", item.Specification);
                                Console.WriteLine("Food Description:    {0}", item.Description);
                                Console.WriteLine("Food Unit Type:      {0}", item.Unit);
                                Console.WriteLine("Food Type:           {0}", item.FoodType);
                            }

                            Console.WriteLine();
                            Console.Write("Enter Food Details ID to add inventory: ");
                            var _addFoodDetailsId = Console.ReadLine();
                            int _addFoodDetailsIdParsed = int.Parse(_addFoodDetailsId);

                            Console.Write("Enter Quantity: ");
                            var _foodQuantity = Console.ReadLine();
                            int _foodQuantityParsed = int.Parse(_foodQuantity);

                            Console.WriteLine("Format - (DD/MM/YYYY)");
                            Console.Write("Enter Expiration Date: ");
                            var _foodExpirationDate = Console.ReadLine();
                            DateTime _foodExpirationDateParsed = DateTime.Parse(_foodExpirationDate);

                            Console.Write("Enter Price: ");
                            var _foodPrice = Console.ReadLine();
                            decimal _foodPriceParsed = decimal.Parse(_foodPrice);

                            Console.Write("Enter Remarks: ");
                            var _foodRemarks = Console.ReadLine();

                            Console.Write("Enter User ID: ");
                            var _foodUserId = Console.ReadLine();
                            int _foodUserIdParsed = int.Parse(_foodUserId);

                            FoodInventory _foodInventory = new FoodInventory
                            {
                                Quantity = _foodQuantityParsed,
                                ExpirationDate = _foodExpirationDateParsed,
                                EncodingDate = DateTime.Now,
                                ItemPrice = _foodPriceParsed,
                                Remarks = _foodRemarks,
                                UserID = _foodUserIdParsed,
                                FoodDetailsID = _addFoodDetailsIdParsed
                            };

                            var _addFoodInventoryCommand = await Mediator.Send(new AddFoodInventoryCommand { MyFoodInventory = _foodInventory });
                            if (_addFoodInventoryCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Inventory successfully added!");
                            }
                            else Console.WriteLine("Failed!");

                            goto foodsubstart;
                        #endregion

                        //case 3 : View Food Details Query
                        #region View Food Details Query
                        case "3":

                            var _viewFoodDetailsQuery = await Mediator.Send(new ViewFoodDetailsQuery());

                            foreach (var item in _viewFoodDetailsQuery)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:     {0}", item.ID);
                                Console.WriteLine("Food Name:           {0}", item.Name);
                                Console.WriteLine("Food Code:           {0}", item.Code);
                                Console.WriteLine("Food Specification:  {0}", item.Specification);
                                Console.WriteLine("Food Description:    {0}", item.Description);
                                Console.WriteLine("Food Unit Type:      {0}", item.Unit);
                                Console.WriteLine("Food Type:           {0}", item.FoodType);

                            }
                            goto foodsubstart;
                        #endregion

                        //case 4 : View Food Stock Query
                        #region View Food Stock Query
                        case "4":

                            Console.WriteLine();
                            var _viewFoodStockQuery = await Mediator.Send(new ViewFoodStockQuery());

                            foreach (var item in _viewFoodStockQuery)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:  {0}", item.ID);
                                Console.WriteLine("Quantity          {0}", item.Quantity);
                                Console.WriteLine("Encoding Date:    {0}", item.EncodingDate);
                                Console.WriteLine("Item Price:       {0}", item.ItemPrice);
                                Console.WriteLine("Remarks:          {0}", item.Remarks);
                            }

                            goto foodsubstart;
                        #endregion

                        //case 5 : Update Food Details Command
                        #region Update Food Details Command
                        case "5":

                            var _viewFoodDetailsQuery1 = await Mediator.Send(new ViewFoodDetailsQuery());

                            foreach (var item in _viewFoodDetailsQuery1)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:     {0}", item.ID);
                                Console.WriteLine("Food Name:           {0}", item.Name);
                                Console.WriteLine("Food Code:           {0}", item.Code);
                                Console.WriteLine("Food Specification:  {0}", item.Specification);
                                Console.WriteLine("Food Description:    {0}", item.Description);
                                Console.WriteLine("Food Unit Type:      {0}", item.Unit);
                                Console.WriteLine("Food Type:           {0}", item.FoodType);
                            }

                            Console.WriteLine();
                            Console.Write("Enter Food Details ID to update: ");
                            var _updateFoodID = Console.ReadLine();
                            var _updateSelectedFoodID = int.Parse(_updateFoodID);


                            Console.Write("Food Name: ");
                            var _foodNameUpdate = Console.ReadLine();

                            Console.Write("Food Code: ");
                            var _foodCodeUpdate = Console.ReadLine();

                            Console.Write("Food Specification: ");
                            var _foodSpecificationUpdate = Console.ReadLine();

                            Console.Write("Food Description: ");
                            var _foodDescriptionUpdate = Console.ReadLine();

                            Console.WriteLine("Food Unit: ");
                            Console.WriteLine("1 - Piece");
                            Console.WriteLine("2 - Box");
                            Console.WriteLine("3 - Dozen");
                            Console.WriteLine("4 - Others");
                            Console.Write("Food Unit: ");
                            var _updateFoodUnit = Console.ReadLine();
                            UnitType _parsedUpdateFoodUnit = (UnitType)Enum.Parse(typeof(UnitType), _updateFoodUnit);

                            Console.WriteLine("Food Type: ");
                            Console.WriteLine("1 - Perishable");
                            Console.WriteLine("2 - Non-perishable");
                            Console.WriteLine("3 - Others");
                            Console.Write("Food Type: ");
                            var _updateFoodType = Console.ReadLine();
                            FoodType _parsedUpdateFoodType = (FoodType)Enum.Parse(typeof(FoodType), _updateFoodType);


                            FoodDetails _foodDetailsUpdate = new FoodDetails
                            {
                                ID = _updateSelectedFoodID,
                                Code = _foodCodeUpdate,
                                Name = _foodNameUpdate,
                                Specification = _foodSpecificationUpdate,
                                Description = _foodDescriptionUpdate,
                                Unit = _parsedUpdateFoodUnit,
                                FoodType = _parsedUpdateFoodType
                            };

                            var _updateFoodDetailsInventoryCommand = await Mediator.Send(new UpdateFoodDetailsCommand { MyFoodDetails = _foodDetailsUpdate });
                            if (_updateFoodDetailsInventoryCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Details Updated!");
                            }


                            goto foodsubstart;
                        #endregion

                        //case 6 : Update Food Stock Command
                        #region Update Food Stock Command
                        case "6":

                            Console.WriteLine();
                            Console.WriteLine("Update Food Stock Inventory");
                            Console.WriteLine();

                            Console.WriteLine();
                            var _viewFoodStockQuery1 = await Mediator.Send(new ViewFoodStockQuery());

                            foreach (var item in _viewFoodStockQuery1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:  {0}", item.ID);
                                Console.WriteLine("Quantity          {0}", item.Quantity);
                                Console.WriteLine("Encoding Date:    {0}", item.EncodingDate);
                                Console.WriteLine("Item Price:       {0}", item.ItemPrice);
                                Console.WriteLine("Remarks:          {0}", item.Remarks);
                            }


                            Console.Write("Enter Food ID: ");
                            var _updateID = Console.ReadLine();
                            int _updatedID = int.Parse(_updateID);

                            Console.WriteLine();
                            Console.Write("Enter New Food Stock: ");
                            var _updateStock = Console.ReadLine();
                            int _updatedFoodStock = int.Parse(_updateStock);


                            var updateFoodStockInventoryCommand = await Mediator.Send(new UpdateFoodStockCommand { SearchedID = _updatedID, NewFoodQuantity = _updatedFoodStock });
                            if (updateFoodStockInventoryCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Stock Updated!");
                            }
                            else Console.WriteLine("Update Failed!");

                            goto foodsubstart;
                        #endregion

                        //case 7 : Delete Food Details Command
                        #region Delete Food Details Command
                        case "7":

                            var _viewFoodDetailsQuery2 = await Mediator.Send(new ViewFoodDetailsQuery());

                            foreach (var item in _viewFoodDetailsQuery2)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:     {0}", item.ID);
                                Console.WriteLine("Food Name:           {0}", item.Name);
                                Console.WriteLine("Food Code:           {0}", item.Code);
                                Console.WriteLine("Food Specification:  {0}", item.Specification);
                                Console.WriteLine("Food Description:    {0}", item.Description);
                                Console.WriteLine("Food Unit Type:      {0}", item.Unit);
                                Console.WriteLine("Food Type:           {0}", item.FoodType);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Enter Food ID Details to delete: ");
                            var _deleteFoodID = Console.ReadLine();
                            int _deleteSelectedFoodID = int.Parse(_deleteFoodID);

                            try
                            {
                                var _deleteFoodDetailsInventoryCommand = await Mediator.Send(new DeleteFoodDetailsCommand { DeleteSearchedID = _deleteSelectedFoodID });
                                if (_deleteFoodDetailsInventoryCommand == true)
                                {
                                    Console.WriteLine("Food Details ID {0} is Deleted!", _deleteSelectedFoodID);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine();
                                Console.WriteLine(ex.Message);
                            }

                            goto foodsubstart;
                        #endregion


                        //case 8 : Request Food Stock Command
                        #region Request Food Stock Command
                        case "8":

                            var _viewFoodDetailsQuery3 = await Mediator.Send(new ViewFoodDetailsQuery());

                            foreach (var item in _viewFoodDetailsQuery3)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Details ID:     {0}", item.ID);
                                Console.WriteLine("Food Name:           {0}", item.Name);
                                Console.WriteLine("Food Code:           {0}", item.Code);
                                Console.WriteLine("Food Specification:  {0}", item.Specification);
                                Console.WriteLine("Food Description:    {0}", item.Description);
                                Console.WriteLine("Food Unit Type:      {0}", item.Unit);
                                Console.WriteLine("Food Type:           {0}", item.FoodType);

                            }

                            Console.WriteLine();
                            Console.Write("Enter Food Details ID to restock: ");
                            var _foodIdRestock = Console.ReadLine();
                            int _selectedFoodIdRestock = int.Parse(_foodIdRestock);

                            Console.Write("Enter Quantity: ");
                            var _foodRestockQuantity = Console.ReadLine();
                            int _foodRestockQuantityParsed = int.Parse(_foodRestockQuantity);

                            Console.Write("Enter User ID: ");
                            var _foodRestockUserId = Console.ReadLine();
                            int _foodRestockUserIdParsed = int.Parse(_foodRestockUserId);

                            FoodRestockRequest _foodRestockRequest = new FoodRestockRequest
                            {
                                FoodsDetailsID = _selectedFoodIdRestock,
                                Quantity = _foodRestockQuantityParsed,
                                DateTimeRequest = DateTime.Now,
                                Status = 0,
                                UserID = _foodRestockUserIdParsed
                            };

                            var _RequestFoodRestockCommand = await Mediator.Send(new RequestFoodRestockCommand { MyFoodRestockRequest = _foodRestockRequest });
                            if (_RequestFoodRestockCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Food Restock Successfully Requested!");
                            }

                            goto foodsubstart;
                        #endregion

                        //case 9 : Search Food by ID Query
                        #region Search Food by ID Command
                        case "9":

                            Console.WriteLine();
                            Console.WriteLine("Search Food By ID");
                            Console.Write("Enter ID: ");
                            var _searchID = Console.ReadLine();
                            int _parsedSearchID = int.Parse(_searchID);


                            var _searchFoodByIdQuery = await Mediator.Send(new SearchFoodByIdQuery { SearchedID = _parsedSearchID });
                            if (_searchFoodByIdQuery != null)
                            {
                                Console.WriteLine("Food Details ID: {0}", _searchFoodByIdQuery.ID);
                                Console.WriteLine("Food Quantity: {0}", _searchFoodByIdQuery.Quantity);
                                Console.WriteLine("Expiration Date: {0}", _searchFoodByIdQuery.ExpirationDate);
                                Console.WriteLine("Food Encoding Date: {0}", _searchFoodByIdQuery.EncodingDate);
                                Console.WriteLine("Food Price: {0}", _searchFoodByIdQuery.ItemPrice);
                                Console.WriteLine("Food Remarks: {0}", _searchFoodByIdQuery.Remarks);
                            }

                            goto foodsubstart;
                        #endregion

                        //case 10 : Search Food by Keyword Query
                        #region Search Food by Keyword Command
                        case "10":

                            Console.WriteLine();
                            Console.WriteLine("Enter Keyword: ");
                            var _searchKeyword = Console.ReadLine();

                            var _searchFoodByKeywordQuery = await Mediator.Send(new SearchFoodByKeywordQuery { SearchedKeyword = _searchKeyword });
                            if (_searchFoodByKeywordQuery != null)
                            {
                                foreach (var item in _searchFoodByKeywordQuery)
                                {
                                    Console.WriteLine("Searched Keyword: {0}", _searchKeyword);
                                    Console.WriteLine("Food Name: {0}   ,   Food Code: {1}", item.Name, item.Code);
                                    Console.WriteLine("Food Specification: {0}   ,   Food Description: {1}", item.Specification, item.Description);
                                }
                            }

                            goto foodsubstart;
                        #endregion


                        default:
                            break;
                    }
                    goto start;


                case "2":

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Equipment Commands");
                    Console.WriteLine();
                    Console.WriteLine("1 - Add Equipment Details");
                    Console.WriteLine("2 - Add Equipment Inventory");
                    Console.WriteLine("3 - View Equipment Details");
                    Console.WriteLine("4 - View Equipment Stock");
                    Console.WriteLine("5 - Update Equipment Details");
                    Console.WriteLine("6 - Update Equipment Stock");
                    Console.WriteLine("7 - Delete Equipment Details");
                    Console.WriteLine("8 - Request Equipment Restock Delivery");
                    Console.WriteLine("9 - Search Equipment By ID");
                    Console.WriteLine("10 - Search Equipment By Keyword");

                equipmentsubstart:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Please enter a sub command: ");
                    string _subCmdNumberEquipment = Console.ReadLine();

                    switch (_subCmdNumberEquipment)
                    {
                        //case 1 : Add Equipment Details Command
                        #region  Add Equipment Details Command
                        case "1":

                            Console.WriteLine("Add Equipment Stock Details");
                            Console.WriteLine();

                            Console.Write("Equipment Code: ");
                            var _equipmentCode = Console.ReadLine();

                            Console.Write("Equipment Name: ");
                            var _equipmentName = Console.ReadLine();

                            Console.Write("Equipment Description: ");
                            var _equipmentDescription = Console.ReadLine();

                            Console.WriteLine("Equipment Unit Type: ");
                            Console.WriteLine("1 - Piece");
                            Console.WriteLine("2 - Box");
                            Console.WriteLine("3 - Dozen");
                            Console.WriteLine("4 - Others");
                            Console.Write("Equipment Unit: ");
                            var _equipmentUnit = Console.ReadLine();
                            UnitType _parsedEquipmentUnit = (UnitType)Enum.Parse(typeof(UnitType), _equipmentUnit);

                            Console.WriteLine("Equipment Type: ");
                            Console.WriteLine("1 - Consumable");
                            Console.WriteLine("2 - Non-consumable");
                            Console.WriteLine("3 - Others");
                            Console.Write("Equipment Type: ");
                            var _equipmentType = Console.ReadLine();
                            EquipmentType _parsedEquipmentType = (EquipmentType)Enum.Parse(typeof(EquipmentType), _equipmentType);


                            EquipmentDetails _equipmentDetails = new EquipmentDetails
                            {
                                Code = _equipmentCode,
                                Name = _equipmentName,
                                Description = _equipmentDescription,
                                UnitType = _parsedEquipmentUnit,
                                EquipmentType = _parsedEquipmentType
                            };

                            var _addEquipmentDetailsCommand = await Mediator.Send(new AddEquipmentDetailsCommand { MyEquipmentDetails = _equipmentDetails });
                            if (_addEquipmentDetailsCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Details Added to Inventory!");
                            }

                            goto equipmentsubstart;
                        #endregion

                        //case 2 : Add Equipment Inventory Command
                        #region Add Equipment Inventory Command
                        case "2":

                            Console.WriteLine();
                            var _viewEquipmentDetails = await Mediator.Send(new ViewEquipmentDetailsQuery());

                            foreach (var item in _viewEquipmentDetails)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Details ID:     {0}", item.ID);
                                Console.WriteLine("Equipment Name:           {0}", item.Name);
                                Console.WriteLine("Equipment Code:           {0}", item.Code);
                                Console.WriteLine("Equipment Description:    {0}", item.Description);
                                Console.WriteLine("Equipment Unit Type:      {0}", item.UnitType);
                                Console.WriteLine("Equipment Type:           {0}", item.EquipmentType);
                            }

                            Console.WriteLine();
                            Console.Write("Enter Equipment Details ID to add inventory: ");
                            var _addEquipmentDetailsId = Console.ReadLine();
                            int _addEquipmentDetailsIdParsed = int.Parse(_addEquipmentDetailsId);

                            Console.Write("Enter Quantity: ");
                            var _equipmentQuantity = Console.ReadLine();
                            int _equipmentQuantityParsed = int.Parse(_equipmentQuantity);

                            Console.Write("Enter Price: ");
                            var _equipmentPrice = Console.ReadLine();
                            decimal _equipmentPriceParsed = decimal.Parse(_equipmentPrice);

                            Console.Write("Enter Remarks: ");
                            var _equipmentRemarks = Console.ReadLine();

                            Console.Write("Enter User ID: ");
                            var _equipmentUserId = Console.ReadLine();
                            int _equipmentUserIdParsed = int.Parse(_equipmentUserId);

                            EquipmentInventory _EquipmentInventory = new EquipmentInventory
                            {
                                Quantity = _equipmentQuantityParsed,
                                EncodingDate = DateTime.Now,
                                ItemPrice = _equipmentPriceParsed,
                                Remarks = _equipmentRemarks,
                                UserID = _equipmentUserIdParsed,
                                EquipmentDetailsID = _addEquipmentDetailsIdParsed
                            };

                            var _addEquipmentInventoryCommand = await Mediator.Send(new AddEquipmentInventoryCommand { MyEquipmentInventory = _EquipmentInventory });
                            if (_addEquipmentInventoryCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Inventory successfully added!");
                            }
                            else Console.WriteLine("Failed!");

                            goto equipmentsubstart;
                        #endregion

                        //case 3 : View Equipment Details Query
                        #region View Equipment Details Query
                        case "3":

                            var _viewequipmentsubstartDetailsQuery = await Mediator.Send(new ViewEquipmentDetailsQuery());

                            foreach (var item in _viewequipmentsubstartDetailsQuery)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Details ID:     {0}", item.ID);
                                Console.WriteLine("Equipment Name:           {0}", item.Name);
                                Console.WriteLine("Equipment Code:           {0}", item.Code);
                                Console.WriteLine("Equipment Description:    {0}", item.Description);
                                Console.WriteLine("Equipment Unit Type:      {0}", item.UnitType);
                                Console.WriteLine("Equipment Type:           {0}", item.EquipmentType);

                            }
                            goto equipmentsubstart;
                        #endregion

                        //case 4 : View Equipment Stock Query
                        #region View Equipment Stock Query
                        case "4":

                            Console.WriteLine();
                            var _viewEquipmentStockQuery = await Mediator.Send(new ViewFoodStockQuery());

                            foreach (var item in _viewEquipmentStockQuery)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Details ID:   {0}", item.ID);
                                Console.WriteLine("Quantity                {0}", item.Quantity);
                                Console.WriteLine("Encoding Date:          {0}", item.EncodingDate);
                                Console.WriteLine("Item Price:             {0}", item.ItemPrice);
                                Console.WriteLine("Remarks:                {0}", item.Remarks);
                            }

                            goto equipmentsubstart;
                        #endregion

                        //case 5 : Update Equipment Details Command
                        #region Update Equipment Details Command
                        case "5":

                            var _viewEquipmentDetailsQuery1 = await Mediator.Send(new ViewEquipmentDetailsQuery());

                            foreach (var item in _viewEquipmentDetailsQuery1)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Equipment Details ID:     {0}", item.ID);
                                Console.WriteLine("Equipment Name:           {0}", item.Name);
                                Console.WriteLine("Equipment Code:           {0}", item.Code);
                                Console.WriteLine("Equipment Description:    {0}", item.Description);
                                Console.WriteLine("Equipment Unit Type:      {0}", item.UnitType);
                                Console.WriteLine("Equipment Type:           {0}", item.EquipmentType);
                            }

                            Console.WriteLine();
                            Console.Write("Enter Equipment Details ID to update: ");
                            var _updateEquipmentID = Console.ReadLine();
                            var _updateSelectedEquipmentID = int.Parse(_updateEquipmentID);


                            Console.Write("Equipment Name: ");
                            var _equipmentNameUpdate = Console.ReadLine();

                            Console.Write("Equipment Code: ");
                            var _equipmentCodeUpdate = Console.ReadLine();

                            Console.Write("Equipment Description: ");
                            var _equipmentDescriptionUpdate = Console.ReadLine();

                            Console.WriteLine("Equipment Unit Type: ");
                            Console.WriteLine("1 - Piece");
                            Console.WriteLine("2 - Box");
                            Console.WriteLine("3 - Dozen");
                            Console.WriteLine("4 - Others");
                            Console.Write("Food Unit: ");
                            var _updateEquipmentUnit = Console.ReadLine();
                            UnitType _parsedUpdateFoodUnit = (UnitType)Enum.Parse(typeof(UnitType), _updateEquipmentUnit);

                            Console.WriteLine("Equipment Type: ");
                            Console.WriteLine("1 - Perishable");
                            Console.WriteLine("2 - Non-perishable");
                            Console.WriteLine("3 - Others");
                            Console.Write("Food Type: ");
                            var _updateEquipmentType = Console.ReadLine();
                            EquipmentType _parsedUpdateEquipmentType = (EquipmentType)Enum.Parse(typeof(EquipmentType), _updateEquipmentType);


                            EquipmentDetails _equipmentDetailsUpdate = new EquipmentDetails
                            {
                                Code = _equipmentCodeUpdate,
                                Name = _equipmentNameUpdate,
                                Description = _equipmentDescriptionUpdate,
                                UnitType = _parsedUpdateFoodUnit,
                                EquipmentType = _parsedUpdateEquipmentType
                            };

                            var _updateEquipmentDetailsInventoryCommand = await Mediator.Send(new UpdateEquipmentDetailsCommand { MyEquipmentDetails = _equipmentDetailsUpdate });
                            if (_updateEquipmentDetailsInventoryCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Details Updated!");
                            }


                            goto equipmentsubstart;
                        #endregion

                        //case 6 : Update Equipment Stock Command
                        #region Update Equipment Stock Command
                        case "6":

                            Console.WriteLine();
                            Console.WriteLine("Update Equipment Stock Inventory");
                            Console.WriteLine();

                            Console.WriteLine();
                            var _viewEquipmentStockQuery1 = await Mediator.Send(new ViewFoodStockQuery());

                            foreach (var item in _viewEquipmentStockQuery1)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Details ID:  {0}", item.ID);
                                Console.WriteLine("Quantity          {0}", item.Quantity);
                                Console.WriteLine("Encoding Date:    {0}", item.EncodingDate);
                                Console.WriteLine("Item Price:       {0}", item.ItemPrice);
                                Console.WriteLine("Remarks:          {0}", item.Remarks);
                            }


                            Console.Write("Enter Equipment ID: ");
                            var _updateID = Console.ReadLine();
                            int _updatedID = int.Parse(_updateID);

                            Console.WriteLine();
                            Console.Write("Enter New Equipment Stock: ");
                            var _updateStock = Console.ReadLine();
                            int _updatedEquipmentStock = int.Parse(_updateStock);


                            var updateEquipmentStockInventoryCommand = await Mediator.Send(new UpdateEquipmentStockCommand { SearchedID = _updatedID, NewEquipmentQuantity = _updatedEquipmentStock });
                            if (updateEquipmentStockInventoryCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Stock Updated!");
                            }
                            else Console.WriteLine("Update Failed!");

                            goto equipmentsubstart;
                        #endregion

                        //case 7 : Delete Equipment Details Command
                        #region Delete Equipment Details Command
                        case "7":

                            var _viewEquipmentDetailsQuery2 = await Mediator.Send(new ViewEquipmentDetailsQuery());

                            foreach (var item in _viewEquipmentDetailsQuery2)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Equipment Details ID:     {0}", item.ID);
                                Console.WriteLine("Equipment Name:           {0}", item.Name);
                                Console.WriteLine("Equipment Code:           {0}", item.Code);
                                Console.WriteLine("Equipment Description:    {0}", item.Description);
                                Console.WriteLine("Equipment Unit Type:      {0}", item.UnitType);
                                Console.WriteLine("Equipment Type:           {0}", item.EquipmentType);
                            }

                            Console.WriteLine();
                            Console.WriteLine("Enter Equipment ID Details to delete: ");
                            var _deleteEquipmentID = Console.ReadLine();
                            int _deleteSelectedEquipmentID = int.Parse(_deleteEquipmentID);

                            try
                            {
                                var _deleteEquipmentDetailsInventoryCommand = await Mediator.Send(new DeleteEquipmentDetailsCommand { DeleteSearchedID = _deleteSelectedEquipmentID });
                                if (_deleteEquipmentDetailsInventoryCommand == true)
                                {
                                    Console.WriteLine("Equipment Details ID {0} is Deleted!", _deleteSelectedEquipmentID);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine();
                                Console.WriteLine(ex.Message);
                            }

                            goto equipmentsubstart;
                        #endregion

                        //case 8 : Request Equipment Stock Command
                        #region Request Equipment Stock Command
                        case "8":

                            var _viewEquipmentDetailsQuery3 = await Mediator.Send(new ViewEquipmentDetailsQuery());

                            foreach (var item in _viewEquipmentDetailsQuery3)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Details ID:     {0}", item.ID);
                                Console.WriteLine("Equipment Name:           {0}", item.Name);
                                Console.WriteLine("Equipment Code:           {0}", item.Code);
                                Console.WriteLine("Equipment Description:    {0}", item.Description);
                                Console.WriteLine("Equipment Unit Type:      {0}", item.UnitType);
                                Console.WriteLine("Equipment Type:           {0}", item.EquipmentType);

                            }

                            Console.WriteLine();
                            Console.Write("Enter Equipment Details ID to restock: ");
                            var _equipmentIdRestock = Console.ReadLine();
                            int _selectedEquipmentIdRestock = int.Parse(_equipmentIdRestock);

                            Console.Write("Enter Quantity: ");
                            var _equipmentRestockQuantity = Console.ReadLine();
                            int _equipmentRestockQuantityParsed = int.Parse(_equipmentRestockQuantity);

                            Console.Write("Enter User ID: ");
                            var _equipmentRestockUserId = Console.ReadLine();
                            int _equipmentRestockUserIdParsed = int.Parse(_equipmentRestockUserId);

                            EquipmentRestockRequest _equipmentRestockRequest = new EquipmentRestockRequest
                            {
                                Quantity = _equipmentRestockQuantityParsed,
                                DateTimeRequest = DateTime.Now,
                                EquipmentDetailsID = _selectedEquipmentIdRestock,
                                Status = 0,
                                UserID = _equipmentRestockUserIdParsed
                            };

                            var _RequestEquipmentRestockCommand = await Mediator.Send(new RequestEquipmentRestockCommand { MyEquipmentRestockRequest = _equipmentRestockRequest });
                            if (_RequestEquipmentRestockCommand == true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Equipment Restock Successfully Requested!");
                            }

                            goto equipmentsubstart;
                        #endregion

                        //case 9 : Search Equipment by ID Query
                        #region Search Equipment by ID Command
                        case "9":

                            Console.WriteLine();
                            Console.WriteLine("Search Equipment By ID");
                            Console.Write("Enter ID: ");
                            var _searchID = Console.ReadLine();
                            int _parsedSearchID = int.Parse(_searchID);


                            var _searchEquipmentByIdQuery = await Mediator.Send(new SearchEquipmentByIdQuery { SearchedID = _parsedSearchID });
                            if (_searchEquipmentByIdQuery != null)
                            {
                                Console.WriteLine("Equipment Details ID: {0}", _searchEquipmentByIdQuery.ID);
                                Console.WriteLine("Equipment Quantity: {0}", _searchEquipmentByIdQuery.Quantity);
                                Console.WriteLine("Equipment Encoding Date: {0}", _searchEquipmentByIdQuery.EncodingDate);
                                Console.WriteLine("Equipmemt Price: {0}", _searchEquipmentByIdQuery.ItemPrice);
                                Console.WriteLine("Equipment Remarks: {0}", _searchEquipmentByIdQuery.Remarks);
                            }

                            goto equipmentsubstart;
                        #endregion

                        //case 10 : Search Equipment by Keyword Query
                        #region Search Equipment by Keyword Command
                        case "10":

                            Console.WriteLine();
                            Console.WriteLine("Enter Keyword: ");
                            var _searchKeyword = Console.ReadLine();

                            var _searchEquipmentByKeywordQuery = await Mediator.Send(new SearchEquipmentByKeywordQuery { SearchedKeyword = _searchKeyword });
                            if (_searchEquipmentByKeywordQuery != null)
                            {
                                foreach (var item in _searchEquipmentByKeywordQuery)
                                {
                                    Console.WriteLine("Searched Keyword: {0}", _searchKeyword);
                                    Console.WriteLine("Equipment Name: {0}   ,   Food Code: {1}", item.Name, item.Code);
                                    Console.WriteLine("Equipment Description: {0}", item.Description);
                                }
                            }

                            goto equipmentsubstart;
                        #endregion


                        default:
                            break;
                    }

                    goto start;
                default:
                    break;
            }
        }
    }
}
