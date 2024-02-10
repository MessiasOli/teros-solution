import packageJson from "../../../package.json"

export default function GetPackageVersion(): string | null {
  try {
    // Pega a versão do objeto
    const version = packageJson.version;

    return version;
  } catch (error) {
    console.error('Erro ao ler o package.json:', error);
    return null;
  }
}
