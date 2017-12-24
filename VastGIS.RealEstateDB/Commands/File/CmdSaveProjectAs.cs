

using System.Windows.Forms;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;

using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Services.Views;
using VastGIS.RealEstate.Api.Interface;
using VastGIS.RealEstateDB.Menu;
using VastGIS.RealEstateDB.Properties;

namespace VastGIS.RealEstateDB.Commands.File
{
    public class CmdSaveProjectAs : BaseCommand
    {
        private IAppContext _context;
        public CmdSaveProjectAs(IAppContext context)
        {
            base._text = "��Ŀ���Ϊ";
            base._key = MenuKeys.SaveProjectAs;
            base._icon = Resources.icon_save_as;
            base._headerName = "tabFile";
            base._toolStripExName = "toolStripFiles";
            _context = context;
        }

        public override void OnClick()
        {
            IProjectService projectService = _context.Container.GetSingleton<IProjectService>();
            if (projectService.SaveAs())
            {
                MessageService.Current.Info("��Ŀ�Ѿ��ɹ�����Ϊ: " + projectService.Filename);
            }
        }
    }

    public class CmdImportDXF : BaseCommand
    {
        private IAppContext _context;
        public CmdImportDXF(IAppContext context)
        {
            base._text = "����DXF";
            base._key = "reImportDXF";
            base._icon = Resources.img_layers32;
            base._headerName = "tabFile";
            base._toolStripExName = "toolStripFiles";
            _context = context;
        }

        public override void OnClick()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "DXFͼ��(*.dxf)|*.dxf";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            if (((IRealEstateContext) _context).RealEstateDatabase != null)
            {
                ProjectLoadingView _loadingForm;
                _loadingForm = new ProjectLoadingView("����DXF����:"+dialog.FileName);
                _context.View.ShowChildView(_loadingForm, false);
                Application.DoEvents();
                _context.View.Lock();
                ((IRealEstateContext)_context).RealEstateDatabase.ImportDxfDrawing(dialog.FileName,_loadingForm);
                _context.View.Unlock();
                _loadingForm.Close();
                _loadingForm.Dispose();
            }
        }
    }
}