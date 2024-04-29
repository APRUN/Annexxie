using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Annexxie.Model;
using Annexxie.Controller;

namespace Annexxie.Pages.Manager
{
    public class StaffModel : PageModel
    {
		private int deleteid;
		[BindProperty]
		public int Deleteid { get => deleteid; set => deleteid = value; }

		Person person;
        //Staff staff;

        [BindProperty]
		public Person Person { get => person; set => person = value; }
        //[BindProperty]
        //public Staff Staff { get => staff; set => staff = value; }

		[BindProperty]
        public List<Staff> Staffs { get; set; }

        [BindProperty]
        public List<Person> Persons { get; set; }

        [BindProperty]
        public List<Lookup> Lookups { get; set; }


		//for deleting

		public async void OnGet()
        {
            try
            {
                Persons= await PersonController.GetPersons();
                Staffs = await StaffController.GetStaffs();
                Lookups = await LookupController.GetLookup();
                person = new Person();
                //staff = new Staff();

			}
            catch(Exception ex)
            {
                TempData["ErrorOnServer"] = ex.Message;
            }
        }
		public async Task<IActionResult> OnPostDeleteStaff()
		{
			try
			{
				await StaffController.DeleteStaff(Deleteid);
				return RedirectToPage("/Manager/Staff");
			}
			catch (Exception ex)
			{
				TempData["ErrorOnServer"] = ex.Message;
				return RedirectToPage("/Manager/Staff");
			}
		}
		public async Task<IActionResult> OnPostAddStaff()
		{
			try
			{
				await PersonController.AddPerson(Person);
				await PersonController.AddPerson(Person);
				return RedirectToPage("/Manager/Staff");
			}
			catch (Exception ex)
			{
				TempData["ErrorOnServer"] = ex.Message;
				return RedirectToPage("/Manager/Staff");
			}
		}
		public async Task<IActionResult> OnPostEditStaff()
		{
			Console.WriteLine(Person.Id);
			return RedirectToPage("/Manager/Staff");
		}
	}
}
